using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Plans
{
    public class GetProductionStepsHandler : IRequestHandler<GetProductionStepsRequest, List<ControlData>>
    {
        public readonly ICRUDRepository<Step> _stepRepository;

        public GetProductionStepsHandler(ICRUDRepository<Step> stepRepository)
        {
            _stepRepository = stepRepository;
        }

        public async Task<List<ControlData>> Handle(GetProductionStepsRequest request, CancellationToken cancellationToken)
        {
            var result = await _stepRepository.GetAll().ToListAsync(cancellationToken);

            return Mapping.Mapper.Map<List<ControlData>>(result);   
        }
    }
}
