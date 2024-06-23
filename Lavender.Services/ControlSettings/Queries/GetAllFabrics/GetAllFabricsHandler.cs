using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
{
    public class GetAllFabricsHandler : IRequestHandler<GetAllFabricsRequest, List<FabricTypeResponse>>
    {
        private readonly ICRUDRepository<FabricType> _fabricTypeRepository;

        public GetAllFabricsHandler(ICRUDRepository<FabricType> fabricTypeRepository)
        {
            _fabricTypeRepository = fabricTypeRepository;
        }

        public async Task<List<FabricTypeResponse>> Handle(GetAllFabricsRequest request, CancellationToken cancellationToken)
        {
            var result = await _fabricTypeRepository.GetAll()
                                                    .Select(FabricTypeResponse.Selector())
                                                    .ToListAsync(cancellationToken);
            return result;
        }
    }
}
