
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class AddItemTypesRequest : IRequest<bool>
    {
        public List<string> TypesName { get; set; } = new List<string>();
    }
}
