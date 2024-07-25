
using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.SewingMachines
{
    public class GetDailyProductivityOfEmpHandler : IRequestHandler<GetDailyProductivityOfEmpRequest, List<DailyProductivityDto>>
    {
        private readonly ICRUDRepository<DailyProduction> _dailyProductionRepository;

        public GetDailyProductivityOfEmpHandler(ICRUDRepository<DailyProduction> dailyProductionRepository)
        {
            _dailyProductionRepository = dailyProductionRepository;
        }

        public async Task<List<DailyProductivityDto>> Handle(GetDailyProductivityOfEmpRequest request, CancellationToken cancellationToken)
        {
            DateOnly firstDayOfMonth, lastDayOfMonth;
          
            if (request.Date == DateOnly.MinValue)
            {
                firstDayOfMonth = DateOnly.MinValue;
                lastDayOfMonth = DateOnly.MaxValue;
            }
            else
            {
               firstDayOfMonth = new DateOnly(request.Date.Year, request.Date.Month, 1);
               lastDayOfMonth = new DateOnly(request.Date.Year, request.Date.Month, DateTime.DaysInMonth(request.Date.Year, request.Date.Month));
            }

            var entities = await _dailyProductionRepository
                          .Find(d => (d.WorkerId == request.WorkerId) &&
                          (d.Day >= firstDayOfMonth && d.Day <= lastDayOfMonth))
                         .ToListAsync(cancellationToken);

            return Mapping.Mapper.Map<List<DailyProductivityDto>>(entities);
                     
        }
    }
}
