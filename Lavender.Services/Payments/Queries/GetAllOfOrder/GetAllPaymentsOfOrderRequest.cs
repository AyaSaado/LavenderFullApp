
using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.Payments
{
    public class GetAllPaymentsOfOrderRequest : IRequest<List<PaymentDto>?>
    {
        public int  OrderId { get; set; }
    }
}
