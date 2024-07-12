

using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using MediatR;


namespace Lavender.Services.Payments
{
    public class UpsertPaymentsOfOrderRequest : IRequest<bool>
    {
        public int OrderId { get; set; }
        public List<PaymentDto> PaymentResponse { get; set; } = null!;
    }

    

}
