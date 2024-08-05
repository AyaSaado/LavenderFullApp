using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
{
    public class DeleteItemDetailsHandler : IRequestHandler<DeleteItemDetailsRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<SItemType> _sItemTypeRepository;

        public DeleteItemDetailsHandler(ICRUDRepository<SItemType> sItemTypeRepository, IUnitOfWork unitOfWork)
        {
            _sItemTypeRepository = sItemTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteItemDetailsRequest request, CancellationToken cancellationToken)
        {
          var entities = await _sItemTypeRepository.Find(l=> request.Ids.Contains(l.Id))
                                                  .ToListAsync(cancellationToken);

          try
          {
                _sItemTypeRepository.RemoveRange(entities);
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
