using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
{
    public class DeleteStoreItemsHandler : IRequestHandler<DeleteStoreItemsRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<StoreItem> _storeItemRepository;

        public DeleteStoreItemsHandler(IUnitOfWork unitOfWork, ICRUDRepository<StoreItem> storeItemRepository)
        {
            _unitOfWork = unitOfWork;
            _storeItemRepository = storeItemRepository;
        }

        public async Task<bool> Handle(DeleteStoreItemsRequest request, CancellationToken cancellationToken)
        {
            var entities = await _storeItemRepository.Find(d => request.Ids.Contains(d.Id))
                                                           .ToListAsync(cancellationToken);

            try
            {
                _storeItemRepository.RemoveRange(entities);
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
