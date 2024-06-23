using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
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
