using Lavender.Core.EntityDto;
using Lavender.Core.Enum;
using MediatR;

namespace Lavender.Services.Orders
{
    public class UpdateOrderRequest : IRequest<bool>
    {
        public int Id { get; set; }    
        public DateOnly DeliveryDate { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int OrderState {  get; set; }
        public string? FeedBack { get; set; }
        public Guid? ProductionLineId { get; set; }
        public ICollection<ItemSizeDto> ItemSizeDtos { get; set; } = new List<ItemSizeDto>();
    }
}
