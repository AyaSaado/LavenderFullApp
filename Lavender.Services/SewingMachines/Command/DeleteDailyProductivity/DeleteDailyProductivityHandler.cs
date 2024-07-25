
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.SewingMachines
{
    public class DeleteDailyProductivityHandler : IRequestHandler<DeleteDailyProductivityRequest, bool>
    {
        private readonly ICRUDRepository<DailyProduction> _dailyProductionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDailyProductivityHandler(IUnitOfWork unitOfWork, ICRUDRepository<DailyProduction> dailyProductionRepository)
        {
            _unitOfWork = unitOfWork;
            _dailyProductionRepository = dailyProductionRepository;
        }

        public async Task<bool> Handle(DeleteDailyProductivityRequest request, CancellationToken cancellationToken)
        {
            var entities = await _dailyProductionRepository.Find(s => request.Ids.Contains(s.Id))
                                                         .ToListAsync(cancellationToken);
            if(request.Ids.Count != entities.Count)
            {
                return false;
            }

            try
            {
                _dailyProductionRepository.RemoveRange(entities);
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
