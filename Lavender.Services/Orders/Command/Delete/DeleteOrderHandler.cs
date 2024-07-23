using Lavender.Core.Entities;
using Lavender.Core.Enum;
using Lavender.Core.Interfaces.Repository;
using Lavender.Infrastructure.LavanderSignalR;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace Lavender.Services.Orders
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<OrderHub, IOrderHub> _orderHubContext;
        private readonly UserManager<User> _userManager;

        public DeleteOrderHandler(IUnitOfWork unitOfWork, IHubContext<OrderHub, IOrderHub> orderHubContext, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _orderHubContext = orderHubContext;
            _userManager = userManager;
        }

        public async Task<bool> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetOneAsync(o => o.Id == request.OrderId, cancellationToken);
            if (order == null) 
            {
                return false;
            }

            var actor = await _unitOfWork.Users.GetOneAsync(a => a.Id == order.ActorId, cancellationToken);
           
            var deleteorderMessage = $"{actor!.FullName} canceled his order of ID: {order.Id}";
            try
            {
                _unitOfWork.Orders.Remove(order);
                await _unitOfWork.Save(cancellationToken);

                await _orderHubContext.Clients.Group(LavenderRoles.Executive.ToString()).ReceiveOrderDeleted(deleteorderMessage);

                var executives = await _userManager.GetUsersInRoleAsync(LavenderRoles.Executive.ToString());

                var unconnectedUsers = executives.Select(e => e.Id.ToString())
                                                 .Except(OrderHub._userConnectionMap.Select(u => u.Key))
                                                 .ToList();

                foreach (var unconnecteduser in unconnectedUsers)
                {
                    // Save the order object for the unconnected user
                    OrderHub._runtimeDeleteObjects.AddOrUpdate(unconnecteduser,
                            new List<string> { deleteorderMessage },
                            (key, existingObjects) =>
                            {
                                existingObjects.Add(deleteorderMessage);
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
