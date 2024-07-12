using MediatR;
using Lavender.Core.Interfaces.Repository;
using Lavender.Services.Payments;
using Lavender.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Lavender.Core.EntityDto;

namespace Lavender.Services
{
    public class GetAllPaymentsOfOrderHandler : IRequestHandler<GetAllPaymentsOfOrderRequest, List<PaymentDto>?>
    {
        private readonly ICRUDRepository<Payment> _paymentRepository;

        public GetAllPaymentsOfOrderHandler(ICRUDRepository<Payment> paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<List<PaymentDto>?> Handle(GetAllPaymentsOfOrderRequest request, CancellationToken cancellationToken)
        {
           return await _paymentRepository.Find(o => o.OrderId == request.OrderId)
                                          .Select(PaymentDto.Selector())
                                          .ToListAsync(cancellationToken);

        }
    }
}
