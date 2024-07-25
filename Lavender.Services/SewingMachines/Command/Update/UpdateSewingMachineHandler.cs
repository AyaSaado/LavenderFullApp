using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.SewingMachines
{
    public class UpdateSewingMachineHandler : IRequestHandler<UpdateSewingMachineRequest, bool>
    {
        private readonly ICRUDRepository<SewingMachine> _sewingMachineRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateSewingMachineHandler(ICRUDRepository<SewingMachine> sewingMachineRepository, IUnitOfWork unitOfWork)
        {
            _sewingMachineRepository = sewingMachineRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateSewingMachineRequest request, CancellationToken cancellationToken)
        {
            var entity = await _sewingMachineRepository.GetOneAsync(s=>s.Id == request.Id, cancellationToken);
            
            if (entity == null)
            {
                return false;
            }

            entity.Code = request.Code;
            entity.Active = request.Active;
            entity.PurchaseDate = request.PurchaseDate;
            entity.ProductionEmpId = request.ProductionEmpId;
            entity.ModelName = Mapping.Mapper.Map<ModelName>(request.ModelNameDto);

            try
            {
                _sewingMachineRepository.Update(entity);
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

