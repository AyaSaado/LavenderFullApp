using Lavender.Core.Interfaces.Repository;
using MediatR;

namespace Lavender.Services.Orders
{
    public class PutLastPriceOfOrderHandler : IRequestHandler<PutLastPriceOfOrderRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PutLastPriceOfOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(PutLastPriceOfOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetOneAsync(o => o.Id == request.OrderId, cancellationToken);

            if (order == null)
            {
                return false;
            }

            order.LastTotalPrice = request.LastTotalPrice;

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
