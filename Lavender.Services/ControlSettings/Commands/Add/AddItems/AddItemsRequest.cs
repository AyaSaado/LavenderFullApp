using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class AddItemsRequest : IRequest<bool>
    {
        public  List<ItemDto> Items { get; set; } = new List<ItemDto>();

    }
}
