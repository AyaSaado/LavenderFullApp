using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class AddLineTypesRequest : IRequest<bool>
    {
        public List<string> LineTypesName { get; set; } = null!;
    }
}
