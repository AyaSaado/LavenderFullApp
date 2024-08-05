using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.ControlSettings
{
    public class AddSTypesHandler : IRequestHandler<AddSTypesRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<SType> _sTypeRepository;

        public AddSTypesHandler(ICRUDRepository<SType> sTypeRepository, IUnitOfWork unitOfWork)
        {
            _sTypeRepository = sTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddSTypesRequest request, CancellationToken cancellationToken)
        {
            var entities = Mapping.Mapper.Map<List<SType>>(request.STypeDtos);

            try
            {
                await _sTypeRepository.AddRangeAsync(entities);
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
