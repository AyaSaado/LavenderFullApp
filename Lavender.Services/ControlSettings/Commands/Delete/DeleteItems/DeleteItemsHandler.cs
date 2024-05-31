using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings.Commands.Delete.DeleteItems
{
    public class DeleteItemsHandler : IRequestHandler<DeleteItemsRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<Item> _itemRepository;

        public DeleteItemsHandler(ICRUDRepository<Item> itemRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteItemsRequest request, CancellationToken cancellationToken)
        {
          var entities = await _itemRepository.Find(l=> request.Ids.Contains(l.Id))
                                                  .ToListAsync(cancellationToken);

          try
          {
                _itemRepository.RemoveRange(entities);
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
