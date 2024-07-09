using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class UpdateItemDetailRequest : IRequest<bool>
    {
        public ItemDetailUpdateRequest ItemDetail { get; set; } = null!;
    }
    public class ItemDetailUpdateRequest
    {
        public int Id { get; set; }
        public string Color { get; set; } = null!;
        public decimal Amount { get; set; }
        public decimal MinAmount { get; set; }
    }

}
