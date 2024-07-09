using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.ControlSettings
{
    public class AddStoreItemsHandler : IRequestHandler<AddStoreItemsRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<StoreItem> _storeItemRepository;

        public AddStoreItemsHandler(ICRUDRepository<StoreItem> storeItemRepository, IUnitOfWork unitOfWork)
        {
            _storeItemRepository = storeItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddStoreItemsRequest request, CancellationToken cancellationToken)
        {
            var entities = Mapping.Mapper.Map<List<StoreItem>>(request.StoreItemDtos);

            try
            {
                await _storeItemRepository.AddRangeAsync(entities);
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
