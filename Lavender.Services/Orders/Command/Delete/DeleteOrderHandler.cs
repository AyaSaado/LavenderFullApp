
using Lavender.Core.Interfaces.Repository;
using MediatR;

namespace Lavender.Services.Orders
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetOneAsync(o => o.Id == request.OrderId, cancellationToken);
            if (order == null) 
            {
                return false;
            }

            try
            {
                _unitOfWork.Orders.Remove(order);
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
