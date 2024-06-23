using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Orders
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetOneAsync(o => o.Id == request.Id, cancellationToken);

            if (order == null)
            {
                return false;
            }

            order.DeliveryDate = request.DeliveryDate;

            order.ItemSizes = Mapping.Mapper.Map<List<ItemSize>>(request.ItemSizeDtos);

            try
            {
                _unitOfWork.Orders.Update(order);
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
