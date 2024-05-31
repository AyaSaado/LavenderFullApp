using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Orders.Command.Add
{
    public class AddOrderHandler : IRequestHandler<AddOrderRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            };

            order.ItemSizes = Mapping.Mapper.Map<List<ItemSize>>(request.ItemSizeDtos);

            try 
            {
                await _unitOfWork.Orders.AddAsync(order);
                await _unitOfWork.Save(cancellationToken);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
