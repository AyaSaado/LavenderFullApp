
using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.SewingMachines
{
    public class UpsertModelNamesRequest : IRequest<bool>
    {
        public List<ModelNameDto> ModelNames { get; set; } = new List<ModelNameDto>();
    }
}
