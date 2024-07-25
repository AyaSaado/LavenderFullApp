using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.SewingMachines
{
    public class GetSewingMachineByIdHandler : IRequestHandler<GetSewingMachineByIdRequest , SewingMachineResponse?>
    {
        private readonly ICRUDRepository<SewingMachine> _sewingMachineRepository;

        public GetSewingMachineByIdHandler(ICRUDRepository<SewingMachine> sewingMachineRepository)
        {
            _sewingMachineRepository = sewingMachineRepository;
        }

        public async Task<SewingMachineResponse?> Handle(GetSewingMachineByIdRequest request, CancellationToken cancellationToken)
        {
            return await _sewingMachineRepository.Find(s => s.Id == request.Id)
                                                 .Select(SewingMachineResponse.Selector())
                                                 .FirstOrDefaultAsync(cancellationToken);

        }
    }
}
