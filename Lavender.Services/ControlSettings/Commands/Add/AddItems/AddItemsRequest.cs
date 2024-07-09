using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class AddItemsRequest : IRequest<bool>
    {
        public  List<string> ItemsName { get; set; } = new List<string>();

    }
}
