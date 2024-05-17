using Lavender.Core.EntityDto;
using Lavender.Core.Shared;
using Lavender.Services.DesignSections.Commands.Add;
using MediatR;

namespace Lavender.Services.DesignSections.Commands.Update
{
    public class UpdateDesignSectionRequest : IRequest<Result<DesignSectionDto>>
    {
        public required int Id { get; set; }
        public required string DesignSectionName { get; set; } 
    }
}
