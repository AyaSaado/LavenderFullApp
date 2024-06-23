using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
{
    public class DeleteAccessoriesHandler : IRequestHandler<DeleteAccessoriesRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<Accessory> _accessoryRepository;

        public DeleteAccessoriesHandler(IUnitOfWork unitOfWork, ICRUDRepository<Accessory> accessoryRepository)
        {
            _unitOfWork = unitOfWork;
            _accessoryRepository = accessoryRepository;
        }

        public async Task<bool> Handle(DeleteAccessoriesRequest request, CancellationToken cancellationToken)
        {
            var entities = await _accessoryRepository.Find(d => request.Ids.Contains(d.Id))
                                                           .ToListAsync(cancellationToken);

            try
            {
                _accessoryRepository.RemoveRange(entities);
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
