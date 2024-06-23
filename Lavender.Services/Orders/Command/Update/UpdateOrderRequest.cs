using Lavender.Core.EntityDto;
using Lavender.Core.Enum;
using MediatR;

namespace Lavender.Services.Orders
{
    public class UpdateOrderRequest : IRequest<bool>
    {
        public int Id { get; set; }    
        public DateOnly DeliveryDate { get; set; }
        public ICollection<ItemSizeDto> ItemSizeDtos { get; set; } = new List<ItemSizeDto>();
    }
}
