
using MediatR;

namespace Lavender.Services.SewingMachines
{
    public class DeleteDailyProductivityRequest : IRequest<bool>
    {
        public List<int> Ids { get; set; } = new List<int>();
    }
}
