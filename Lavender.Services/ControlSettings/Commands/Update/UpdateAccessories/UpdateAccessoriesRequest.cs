using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class UpdateAccessoriesRequest : IRequest<bool>
    {

        public ICollection<ControlData> Accessories { get; set; } = null!;
    }
}
