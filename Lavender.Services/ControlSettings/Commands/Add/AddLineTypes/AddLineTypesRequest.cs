using MediatR;

namespace Lavender.Services.ControlSettings.Commands.Add.AddLineTypes
{
    public class AddLineTypesRequest : IRequest<bool>
    {
        public List<string> LineTypesName { get; set; } = null!;
    }
}
