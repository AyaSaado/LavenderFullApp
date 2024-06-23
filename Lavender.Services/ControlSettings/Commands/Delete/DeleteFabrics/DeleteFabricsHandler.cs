using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
{
    public class DeleteFabricsHandler : IRequestHandler<DeleteFabricsRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<FabricType> _fabricTypeRepository;

        public DeleteFabricsHandler(ICRUDRepository<FabricType> fabricTypeRepository, IUnitOfWork unitOfWork)
        {
            _fabricTypeRepository = fabricTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteFabricsRequest request, CancellationToken cancellationToken)
        {
            var entities = await _fabricTypeRepository.Find(d => request.Ids.Contains(d.Id))
                                                          .ToListAsync(cancellationToken);

            try
            {
                _fabricTypeRepository.RemoveRange(entities);
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
