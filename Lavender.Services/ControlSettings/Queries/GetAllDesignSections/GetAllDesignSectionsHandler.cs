using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Services.ControlSettings.Queries.GetAllDesignSections.GetAllDesignSectionsRequest;

namespace Lavender.Services.ControlSettings.Queries.GetAllDesignSections
{
    public class GetAllDesignSectionsHandler : IRequestHandler<GetAllDesignSectionsRequest, List<DesignSectionResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDesignSectionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DesignSectionResponse>> Handle(GetAllDesignSectionsRequest request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.DesignSections.GetAll()
                                                         .Select(DesignSectionResponse.Selector())
                                                         .ToListAsync(cancellationToken);
                                                       
            return result;

        }
    }
}
