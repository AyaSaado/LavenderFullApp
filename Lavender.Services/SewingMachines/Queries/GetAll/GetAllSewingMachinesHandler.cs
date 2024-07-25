

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
           return await _sewingMachineRepository.Find(s=>( request.MachineNameId == 0 ||s.ModelNameId == request.MachineNameId)
                                                                &&(request.ProductionEmpId == null || s.ProductionEmpId == request.ProductionEmpId) )
                                                        .Select(SewingMachineResponse.Selector())  
                                                        .ToListAsync(cancellationToken);

        }
    }
}
