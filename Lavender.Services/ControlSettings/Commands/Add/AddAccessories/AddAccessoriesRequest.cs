
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class AddAccessoriesRequest  : IRequest<bool>
    {
        public List<string> AccessoriesName { get; set; } = new List<string>();
    }
}
