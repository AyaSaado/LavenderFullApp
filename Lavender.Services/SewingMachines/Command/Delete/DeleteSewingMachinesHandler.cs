
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.SewingMachines
{
    public class DeleteSewingMachinesHandler : IRequestHandler<DeleteSewingMachinesRequest, bool>
    {
        private readonly ICRUDRepository<SewingMachine> _sewingMachineRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSewingMachinesHandler(IUnitOfWork unitOfWork, ICRUDRepository<SewingMachine> sewingMachineRepository)
        {
            _unitOfWork = unitOfWork;
            _sewingMachineRepository = sewingMachineRepository;
        }

        public async Task<bool> Handle(DeleteSewingMachinesRequest request, CancellationToken cancellationToken)
        {
            var entities = await _sewingMachineRepository.Find(s => request.Ids.Contains(s.Id))
                                                         .ToListAsync(cancellationToken);
            if(request.Ids.Count != entities.Count)
            {
                return false;
            }

            try
            {
                _sewingMachineRepository.RemoveRange(entities);
                await _unitOfWork.Save(cancellationToken);

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
