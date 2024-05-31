

using MediatR;

namespace Lavender.Services.ControlSettings.Commands.Add.AddItems
{
    public class AddItemsRequest : IRequest<bool>
    {
        public  List<string> ItemsName { get; set; } = new List<string>();
    }
}
