using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
{
    public class DeleteSTypesHandler : IRequestHandler<DeleteSTypesRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<SType> _sTypeRepository;

        public DeleteSTypesHandler(ICRUDRepository<SType> sTypeRepository, IUnitOfWork unitOfWork)
        {
            _sTypeRepository = sTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteSTypesRequest request, CancellationToken cancellationToken)
        {
            var entities = await _sTypeRepository.Find(d => request.Ids.Contains(d.Id))
                                                          .ToListAsync(cancellationToken);

            try
            {
                _sTypeRepository.RemoveRange(entities);
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
