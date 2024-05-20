using Lavender.Core.EntityDto;
using Lavender.Core.Shared;
using MediatR;

namespace Lavender.Services.ControlSettings.Commands.Add.AddDesignSections
{
    public class AddDesignSectionsRequest : IRequest<bool>
    {
        public List<string> DesignSectionsName { get; set; } = null!;
    }

}
