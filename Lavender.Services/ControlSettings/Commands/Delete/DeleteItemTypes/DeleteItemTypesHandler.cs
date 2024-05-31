using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings.Commands.Delete.DeleteItemTypes
{
    public class DeleteItemTypesHandler : IRequestHandler<DeleteItemTypesRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<ItemType> _itemTypeRepository;

        public DeleteItemTypesHandler(ICRUDRepository<ItemType> itemTyperepository, IUnitOfWork unitOfWork)
        {
            _itemTypeRepository = itemTyperepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteItemTypesRequest request, CancellationToken cancellationToken)
        {
          var entities = await _itemTypeRepository.Find(l=> request.Ids.Contains(l.Id))
                                                  .ToListAsync(cancellationToken);

          try
          {
                _itemTypeRepository.RemoveRange(entities);
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
