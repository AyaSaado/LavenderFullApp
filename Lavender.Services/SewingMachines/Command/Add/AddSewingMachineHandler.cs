using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.SewingMachines 
{ 
    public class AddSewingMachineHandler : IRequestHandler<AddSewingMachineRequest, bool>
    {
        private readonly ICRUDRepository<SewingMachine> _sewingMachineRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddSewingMachineHandler(ICRUDRepository<SewingMachine> sewingMachineRepository, IUnitOfWork unitOfWork)
        {
            this._sewingMachineRepository = sewingMachineRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddSewingMachineRequest request, CancellationToken cancellationToken)
        {
            var sewingmachine = new SewingMachine()
            {
                Code = request.Code,
                Active = false,
                PurchaseDate = request.PurchaseDate,
                ProductionEmpId = request.ProductionEmpId,   
                ModelNameId = request.ModelNameId
            };
  

            try
            {
                await _sewingMachineRepository.AddAsync(sewingmachine);
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
