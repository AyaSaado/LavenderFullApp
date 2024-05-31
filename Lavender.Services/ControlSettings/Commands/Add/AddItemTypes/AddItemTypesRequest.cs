
using MediatR;

namespace Lavender.Services.ControlSettings.Commands.Add.AddtemTypes
{
    public class AddItemTypesRequest : IRequest<bool>
    {
        public List<string> TypesName { get; set; } = new List<string>();
    }
}
