using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.SewingMachines
{
    public class GetModelNameRequest : IRequest<List<ModelNameDto>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
