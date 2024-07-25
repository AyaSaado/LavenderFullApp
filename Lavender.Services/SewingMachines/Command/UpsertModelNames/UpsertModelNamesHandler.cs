using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.SewingMachines
{
    public class UpsertModelNamesHandler : IRequestHandler<UpsertModelNamesRequest, bool>
    {
        private readonly ICRUDRepository<ModelName> _modelNameRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpsertModelNamesHandler(ICRUDRepository<ModelName> modelNameRepository, IUnitOfWork unitOfWork)
        {
            _modelNameRepository = modelNameRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpsertModelNamesRequest request, CancellationToken cancellationToken)
        {
            var entities = Mapping.Mapper.Map<List<ModelName>>(request.ModelNames);

            try
            {
                _modelNameRepository.UpdateRange(entities);
                await _unitOfWork.Save(cancellationToken);
                
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }
    }
}
