using MediatR;

namespace Lavender.Services.Orders
{
    public class PutLastPriceOfOrderRequest : IRequest<bool>
    {
        public int OrderId { get; set; }    
        public decimal LastTotalPrice { get; set; }
    }
}
