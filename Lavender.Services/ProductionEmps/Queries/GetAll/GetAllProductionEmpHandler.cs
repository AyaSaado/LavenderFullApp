using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.ProductionEmps.Queries.GetAll
{
    public class GetAllProductionEmpHandler : IRequestHandler<GetAllProductionEmpRequest, List<ProductionEmpDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductionEmpHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ProductionEmpDto>> Handle(GetAllProductionEmpRequest request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.ProductionEmps.GetAll().ToListAsync(cancellationToken);

            return Mapping.Mapper.Map<List<ProductionEmpDto>>(entities);
        }
    }
}
