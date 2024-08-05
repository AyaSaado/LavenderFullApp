using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.Orders
{
    public class DeleteIRawItemsOfOrderHandler : IRequestHandler<DeleteRawItemsOfOrderRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<Consuming> _consumingRepository;

        public DeleteIRawItemsOfOrderHandler(ICRUDRepository<Consuming> consumingRepository, IUnitOfWork unitOfWork)
        {
            _consumingRepository = consumingRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteRawItemsOfOrderRequest request, CancellationToken cancellationToken)
        {
          var entities = await _consumingRepository.Find(l=> request.Ids.Contains(l.Id))
                                                  .ToListAsync(cancellationToken);

          try
          {
                _consumingRepository.RemoveRange(entities);
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
