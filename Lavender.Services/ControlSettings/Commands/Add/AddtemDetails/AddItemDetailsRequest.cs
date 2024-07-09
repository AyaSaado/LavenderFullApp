
using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class AddItemDetailsRequest : IRequest<bool>
    {
        public List<ItemDetailsRequest> ItemDetailsRequest { get; set; } = new List<ItemDetailsRequest>();

    }

    public class ItemDetailsRequest
    {
        public ControlData stype { get; set; } = null!;
        public string Color { get; set; } = null!;
        public decimal Amount { get; set; }
        public int StoreItemId { get; set; }
        public decimal MinAmount { get; set; }

    }
}
