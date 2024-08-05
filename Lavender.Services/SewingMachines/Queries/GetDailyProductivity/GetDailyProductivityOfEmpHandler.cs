
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
            DateOnly startDate;
            DateOnly endDate;

            // Determine the date range based on request parameters
          
            if (request.FromDate != DateOnly.MinValue && request.ToDate != DateOnly.MinValue)
            {
                startDate = request.FromDate;
                endDate = request.ToDate;
            }
            else if (request.Date != DateOnly.MinValue)
            {
                startDate = request.Date;
                endDate = request.Date;
            }
            else
            {
                // Fallback in case no valid filters are provided
                endDate = DateOnly.FromDateTime(DateTime.Today);
                startDate = endDate.AddDays(-7); // Default to last week
            }

            var entities = await _dailyProductionRepository
                          .Find(d => d.WorkerId == request.WorkerId &&
                                      (d.Day >= startDate && d.Day <= endDate))
                          .OrderByDescending(d => d.Day)
                          .ToListAsync(cancellationToken);

            return Mapping.Mapper.Map<List<DailyProductivityDto>>(entities);
        }
    }
}
