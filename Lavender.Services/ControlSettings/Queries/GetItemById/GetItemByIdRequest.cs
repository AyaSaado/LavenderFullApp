using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class GetItemByIdRequest : IRequest<ItemDto?>
    {
        public int ItemId { get; set; }
    }
}
