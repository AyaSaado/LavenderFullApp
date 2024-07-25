using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.SewingMachines
{
    public class UpsertDailyProductivityHandler : IRequestHandler<UpsertDailyProductivityRequest, bool>
    {
        private readonly ICRUDRepository<DailyProduction> _dailyProductionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertDailyProductivityHandler(ICRUDRepository<DailyProduction> dailyProductionRepository, IUnitOfWork unitOfWork)
        {
            _dailyProductionRepository = dailyProductionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpsertDailyProductivityRequest request, CancellationToken cancellationToken)
        {
            var entities = Mapping.Mapper.Map<List<DailyProduction>>(request.DailyProductivities);

            try
            {
                _dailyProductionRepository.UpdateRange(entities);
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
