using Lavender.Core.EntityDto;
using Lavender.Core.Shared;
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class AddDesignSectionsRequest : IRequest<bool>
    {
        public List<string> DesignSectionsName { get; set; } = null!;
    }

}
