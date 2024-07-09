using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
{
    public class GetAllSTypesHandler : IRequestHandler<GetAllSTypesRequest, List<STypeResponse>>
    {
        private readonly ICRUDRepository<SType> _sTypeRepository;

        public GetAllSTypesHandler(ICRUDRepository<SType> sTypeRepository)
        {
            _sTypeRepository = sTypeRepository;
        }

        public async Task<List<STypeResponse>> Handle(GetAllSTypesRequest request, CancellationToken cancellationToken)
        {
            var result = await _sTypeRepository.GetAll()
                                                    .Select(STypeResponse.Selector())
                                                    .ToListAsync(cancellationToken);
            return result;
        }
    }
}
