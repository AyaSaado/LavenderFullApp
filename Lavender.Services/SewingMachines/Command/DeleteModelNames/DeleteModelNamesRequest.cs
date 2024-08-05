
using MediatR;

namespace Lavender.Services.SewingMachines
{
    public class DeleteModelNamesRequest : IRequest<bool>
    {
        public List<Guid> Ids { get; set; } = new List<Guid>();
    }
}
