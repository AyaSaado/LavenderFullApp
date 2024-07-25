
using MediatR;

namespace Lavender.Services.SewingMachines
{
    public class DeleteSewingMachinesRequest : IRequest<bool>
    {
        public List<int> Ids { get; set; } = new List<int>();
    }
}
