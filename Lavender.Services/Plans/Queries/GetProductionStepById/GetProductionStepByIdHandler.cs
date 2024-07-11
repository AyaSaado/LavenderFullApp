
using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Plans
{
    public class GetProductionStepByIdHandler : IRequestHandler<GetProductionStepByIdRequest, ControlData>
    {
        public readonly ICRUDRepository<Step> _stepRepository;

        public GetProductionStepByIdHandler(ICRUDRepository<Step> stepRepository)
        {
            _stepRepository = stepRepository;
        }

        public async Task<ControlData> Handle(GetProductionStepByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _stepRepository.GetOneAsync(s=>s.Id == request.ProductionStepId, cancellationToken); 
            
            return Mapping.Mapper.Map<ControlData>(result); 
        }
    }
}
