

using MediatR;

namespace Lavender.Services.Payments
{
    public class DeletePaymentsOfOrderRequest : IRequest<bool>
    {
        public List<int> Ids { get; set; } = null!;
    }
}
