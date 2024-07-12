using MediatR;
using Lavender.Core.Interfaces.Repository;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Payments
{
    public class UpsertPaymentsOfOrderHandler : IRequestHandler<UpsertPaymentsOfOrderRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;


        public UpsertPaymentsOfOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpsertPaymentsOfOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetOneAsync(o => o.Id == request.OrderId, cancellationToken);

            if (order == null)
            {
                return false;
            }

            Mapping.Mapper.Map(request.PaymentResponse , order.Payments);

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
