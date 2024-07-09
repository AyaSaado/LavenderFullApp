using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class AddItemTypesRequest : IRequest<bool>
    {
        public  List<string> ItemsName { get; set; } = new List<string>();

    }
}
