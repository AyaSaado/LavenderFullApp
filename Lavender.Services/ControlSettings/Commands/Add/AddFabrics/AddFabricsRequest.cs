

using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class AddFabricsRequest : IRequest<bool>
    {
        public List<string> FabricTypesName { get; set; } = new List<string>();
    }
}
