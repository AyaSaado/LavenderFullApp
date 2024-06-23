
using MediatR;

namespace Lavender.Services.Orders
{
    public class DeleteOrderRequest : IRequest<bool>
    {
        public int OrderId { get; set; }
    }
}
