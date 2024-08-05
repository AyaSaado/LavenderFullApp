using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class UpdateItemsRequest : IRequest<bool>
    {
        public  List<ItemDto> Items { get; set; } = new List<ItemDto>();

    }
}
