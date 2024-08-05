

using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.SewingMachines
{
    public class GetAllSewingMachinesHandler : IRequestHandler<GetAllSewingMachinesRequest, List<SewingMachineResponse>>
    {
        private readonly ICRUDRepository<SewingMachine> _sewingMachineRepository;

        public GetAllSewingMachinesHandler(ICRUDRepository<SewingMachine> sewingMachineRepository)
        {
            _sewingMachineRepository = sewingMachineRepository;
        }

        public async Task<List<SewingMachineResponse>> Handle(GetAllSewingMachinesRequest request, CancellationToken cancellationToken)
        {
            if (request.ModelNameId == Guid.Empty) request.ModelNameId = null;

           return await _sewingMachineRepository.Find(s=>  ((request.Code == 0) || (s.Code == request.Code))
                                                         &&((request.ModelNameId == null )||(s.ModelNameId == request.ModelNameId))
                                                         &&((s.ProductionEmp.HeadId == request.ProductionEmpId)||(s.ProductionEmpId == request.ProductionEmpId)))
                                                        .Select(SewingMachineResponse.Selector())  
                                                        .ToListAsync(cancellationToken);

        }
    }
}
