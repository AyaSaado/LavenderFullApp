using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.SewingMachines
{
    public class UpsertDailyProductivityRequest : IRequest<bool>
    {
        public List<DailyProductivityDto> DailyProductivities { get; set; } = new List<DailyProductivityDto>(); 
    }
  
}
