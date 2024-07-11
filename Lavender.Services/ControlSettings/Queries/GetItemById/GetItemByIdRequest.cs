using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class GetItemByIdRequest : IRequest<ItemResponse?>
    {
        public int ItemId { get; set; }
    }
}
