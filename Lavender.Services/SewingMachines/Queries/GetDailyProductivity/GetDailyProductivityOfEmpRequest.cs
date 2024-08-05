using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.SewingMachines
{
    public class GetDailyProductivityOfEmpRequest : IRequest<List<DailyProductivityDto>>
    {
        public int WorkerId { get; set; }
        public DateOnly Date { get; set; } = DateOnly.MinValue; // Specific day
        public DateOnly FromDate { get; set; } = DateOnly.MinValue; // Range start
        public DateOnly ToDate { get; set; } = DateOnly.MinValue; // Range end
 
    }
}
