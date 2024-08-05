using Lavender.Core.Entities;
using Lavender.Core.Enum;
using Lavender.Core.Interfaces.Repository;
using Lavender.Infrastructure.LavanderSignalR;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Orders
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<OrderHub, IOrderHub> _orderHubContext;
        private readonly UserManager<User> _userManager;

        public UpdateOrderHandler(IUnitOfWork unitOfWork, IHubContext<OrderHub, IOrderHub> orderHubContext, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _orderHubContext = orderHubContext;
            _userManager = userManager;
        }

        public async Task<bool> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetOneAsync(o => o.Id == request.Id, cancellationToken);

            if (order == null)
            {
                return false;
            }
             
            bool newProduction = ((request.ProductionLineId == Guid.Empty ? null : request.ProductionLineId) != order.ProductionLineId); 
            bool newfeedback = (request.FeedBack != order.Feedback);
            bool EndOrderNow = (request.EndDate != order.EndDate);

            if (newProduction)
            {
                order.ProductionLineId = request.ProductionLineId;
            }

            order.DeliveryDate = request.DeliveryDate;
            order.Feedback = request.FeedBack;
            order.ItemSizes = Mapping.Mapper.Map<List<ItemSize>>(request.ItemSizeDtos);
            order.EndDate = request.EndDate;
            order.OrderState = (OrderState) request.OrderState;
            order.StartDate = request.StartDate;    

            if (EndOrderNow)
            {
                order.OrderState = OrderState.outlet;
            }

            try
            {
                _unitOfWork.Orders.Update(order);
                await _unitOfWork.Save(cancellationToken);

                var getorder = await _unitOfWork.Orders.Find(o => o.Id == order.Id)
                                                       .Select(OrdersResponse.Selector())
                                                       .FirstOrDefaultAsync(cancellationToken);
                                                 
                getorder!.ItemsCount = order.ItemSizes.SelectMany(i => i.ItemSizeWithColors).Sum(i => i.Amount);
               
                if (order.GalleryDesignId != 0)
                {
                    var design = await _unitOfWork.Designs.GetOneAsync(d => d.Id == order.GalleryDesignId, cancellationToken);

                    getorder.DesignPrice = design!.DesignPrice - design.DesignPrice * (design.Discount / 100);

                    getorder.TotalPrice = getorder.DesignPrice * getorder.ItemsCount;
                }

                var jsonOrder = JsonConvert.SerializeObject(getorder, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.None // Optional: for pretty-printing the JSON
                });

                // Ugly Code just working  

                if (newProduction && (order.ProductionLineId != Guid.Empty))
                {
                    if (OrderHub._userConnectionMap.TryGetValue(order.ProductionLineId.ToString()!, out var connectionId))
                    {
                        await _orderHubContext.Clients.Client(connectionId).ReceiveOrderToProduction(jsonOrder);
                    }
                    else
                    { 
                        // production manager isn't connected 
                        OrderHub._runtimeAddObjectsToProd.AddOrUpdate(order.ProductionLineId.ToString()!,
                                new List<string> { jsonOrder },
                                (key, existingObjects) =>
                                {
                                    existingObjects.Add(jsonOrder);
                                    return existingObjects;
                                });
                    }
                   
                }
                else if( newfeedback && !order.Feedback.IsNullOrEmpty())
                {
                    await _orderHubContext.Clients.Group(LavenderRoles.Executive.ToString()).ReceiveFeedBackOfOrder(order.Id , order.Feedback!);

                    var executives = await _userManager.GetUsersInRoleAsync(LavenderRoles.Executive.ToString());

                    var unconnectedUsers = executives.Select(e => e.Id.ToString())
                                                     .Except(OrderHub._userConnectionMap.Select(u => u.Key))
                                                     .ToList();

                    foreach (var unconnecteduser in unconnectedUsers)
                    {
                        // Save the order object for the unconnected user
                        OrderHub._runtimeAddFeedBack.AddOrUpdate(unconnecteduser,
                                new Dictionary<int, string> { { order.Id, order.Feedback! } },
                                 (key, existingObjects) =>
                                 {
                                     existingObjects.Add(order.Id, order.Feedback!);
                                     return existingObjects;
                                 });

                    }

                    if (OrderHub._userConnectionMap.TryGetValue(order.ActorId.ToString()!, out var connectionId))
                    {
                        await _orderHubContext.Clients.Client(connectionId)
                                                  .ReceiveFeedBackOfOrder(order.Id ,order.Feedback!);
                    }
                    else
                    {
                        OrderHub._runtimeAddFeedBack.AddOrUpdate(order.ActorId.ToString(),
                                 new Dictionary<int, string> { { order.Id, order.Feedback! } },
                                 (key, existingObjects) =>
                                 {
                                     existingObjects.Add(order.Id, order.Feedback!);
                                     return existingObjects;
                                 });
                    }

                }
                else if(EndOrderNow)
                {
                    if (OrderHub._userConnectionMap.TryGetValue(order.ActorId.ToString()!, out var connectionId))
                    {
                        await _orderHubContext.Clients.Client(connectionId)
                                                  .ReceiveOrderFinished(order.Id,order.EndDate.ToString());
                    }
                    else
                    {
                        OrderHub._runtimeFinishedObjects.AddOrUpdate(order.ActorId.ToString(),
                                new Dictionary<int,string> { { order.Id, order.EndDate.ToString() } },
                                (key, existingObjects) =>
                                {
                                    existingObjects.Add(order.Id,order.EndDate.ToString());
                                    return existingObjects;
                                });
                    }
                }
                else // Customer upbdate order details
                {
                    if (order.ProductionLineId != Guid.Empty)
                    {
                        if (OrderHub._userConnectionMap.TryGetValue(order.ProductionLineId.ToString()!, out var connectionId))
                        {
                            await _orderHubContext.Clients.Client(connectionId).ReceiveOrderUpdated(jsonOrder);
                        }
                        else
                        {
                            OrderHub._runtimeUpdateObjects.AddOrUpdate(order.ProductionLineId.ToString()!,
                                    new List<string> { jsonOrder },
                                    (key, existingObjects) =>
                                    {
                                        existingObjects.Add(jsonOrder);
                                        return existingObjects;
                                    });
                        }
                    }
                    await _orderHubContext.Clients.Group(LavenderRoles.Executive.ToString()).ReceiveOrderUpdated(jsonOrder);

                    var executives = await _userManager.GetUsersInRoleAsync(LavenderRoles.Executive.ToString());

                    var unconnectedUsers = executives.Select(e => e.Id.ToString())
                                                     .Except(OrderHub._userConnectionMap.Select(u => u.Key))
                                                     .ToList();

                    foreach (var unconnecteduser in unconnectedUsers)
                    {
                        // Save the order object for the unconnected user
                        OrderHub._runtimeUpdateObjects.AddOrUpdate(unconnecteduser,
                                new List<string> { jsonOrder },
                                (key, existingObjects) =>
                                {
                                    existingObjects.Add(jsonOrder);
                                    return existingObjects;
                                });

                    }
      
                }
                return true;
            }
            catch(Exception) 
            {
                return false;
            }

        }
    }
}
