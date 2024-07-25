using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.SewingMachines
{
    public class GetDailyProductivityOfEmpRequest : IRequest<List<DailyProductivityDto>>
    {
        public int WorkerId { get; set; }
        public DateOnly Date { get; set; } = DateOnly.MinValue;   
    }
}
