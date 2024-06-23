using Lavender.Core.EntityDto;
using Lavender.Core.Enum;
using MediatR;

namespace Lavender.Services.Orders
{
    public class AddOrderRequest : IRequest<bool>
    {
        public DateOnly OrderDate { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public Ordertype OrderType { get; set; }
        public Guid ActorId { get; set; }
        public int ItemId { get; set; }
        public int ItemTypeId { get; set; } 
        public ICollection<ItemSizeDto> ItemSizeDtos { get; set; } = new List<ItemSizeDto>();

    }
}
