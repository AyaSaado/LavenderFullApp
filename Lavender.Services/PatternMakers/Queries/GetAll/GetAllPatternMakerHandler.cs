using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.PatternMakers.Queries.GetAll
{
    public class GetAllPatternMakerHandler : IRequestHandler<GetAllPatternMakerRequest, List<PatternMakerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPatternMakerHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PatternMakerDto>> Handle(GetAllPatternMakerRequest request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.PatternMakers.GetAll().ToListAsync(cancellationToken);

            var result = Mapping.Mapper.Map<List<PatternMakerDto>>(entities);

            
            return result;
        }
    }
}
