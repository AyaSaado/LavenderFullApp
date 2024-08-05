
using MediatR;

namespace Lavender.Services.Orders
{
    public class DeleteRawItemsOfOrderRequest : IRequest<bool>
    {
        public List<int> Ids { get; set; } = new List<int>();
    }
}
