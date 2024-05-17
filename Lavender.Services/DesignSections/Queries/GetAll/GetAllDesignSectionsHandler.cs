
using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.DesignSections.Queries.GetAll
{
    public class GetAllDesignSectionsHandler : IRequestHandler<GetAllDesignSectionsRequest, List<DesignSectionDto>?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDesignSectionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DesignSectionDto>?> Handle(GetAllDesignSectionsRequest request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.DesignSections.GetAll().ToListAsync(cancellationToken);

            return Mapping.Mapper.Map<List<DesignSectionDto>>(entities);

        }
    }
}
