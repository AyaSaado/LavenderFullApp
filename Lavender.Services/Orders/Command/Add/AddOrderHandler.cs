using Lavender.Core.Entities;
using Lavender.Core.Enum;
using Lavender.Core.Interfaces.Repository;
using Lavender.Infrastructure.LavanderSignalR;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using static Lavender.Core.Helper.MappingProfile;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.Orders
{
    public class AddOrderHandler : IRequestHandler<AddOrderRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<OrderHub, IOrderHub> _orderHubContext;
        private readonly UserManager<User> _userManager;

        public AddOrderHandler(IUnitOfWork unitOfWork, IHubContext<OrderHub, IOrderHub> orderHubContext, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _orderHubContext = orderHubContext;
            _userManager = userManager;
        }

        public async Task<bool> Handle(AddOrderRequest request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                ActorId = request.ActorId,
                ItemId = request.ItemId,
                ItemTypeId = request.ItemTypeId,
                DeliveryDate = request.DeliveryDate,
                OrderDate = request.OrderDate,
                OrderType = request.OrderType,
                GalleryDesignId = request.GalleryDesignId,
                OrderState = 0
            };

            order.ItemSizes = Mapping.Mapper.Map<List<ItemSize>>(request.ItemSizeDtos);

            try 
            {
                await _unitOfWork.Orders.AddAsync(order);
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

                await _orderHubContext.Clients.Group(LavenderRoles.Executive.ToString()).ReceiveOrderCreated(jsonOrder);

                var executives = await _userManager.GetUsersInRoleAsync(LavenderRoles.Executive.ToString());
               
                var unconnectedUsers = executives.Select(e=>e.Id.ToString())
                                                 .Except( OrderHub._userConnectionMap.Select(u=>u.Key))
                                                 .ToList();

                foreach (var unconnecteduser in unconnectedUsers)
                {
                    // Save the order object for the unconnected user
                        OrderHub._runtimeAddObjects.AddOrUpdate(unconnecteduser,
                                new List<string> { jsonOrder },
                                (key, existingObjects) =>
                                {
                                    existingObjects.Add(jsonOrder);
                                    return existingObjects;
                                });

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
