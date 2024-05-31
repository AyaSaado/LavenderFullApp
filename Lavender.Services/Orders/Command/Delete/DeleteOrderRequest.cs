
using MediatR;

namespace Lavender.Services.Orders.Command.Delete
{
    public class DeleteOrderRequest : IRequest<bool>
    {
        public int OrderId { get; set; }
    }
}
