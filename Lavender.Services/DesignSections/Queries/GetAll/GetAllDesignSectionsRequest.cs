

using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.DesignSections.Queries.GetAll
{
    public class GetAllDesignSectionsRequest : IRequest<List<DesignSectionDto>?>
    {
    }
}
