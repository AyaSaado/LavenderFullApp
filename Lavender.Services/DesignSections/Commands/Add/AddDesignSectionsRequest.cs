
using Lavender.Core.EntityDto;
using Lavender.Core.Shared;
using MediatR;

namespace Lavender.Services.DesignSections.Commands.Add
{
    public class AddDesignSectionsRequest : IRequest<Result<List<DesignSectionDto>>>
    {
        public List<string> DesignSectionsName { get; set; } = null!;    
    }
  
}
