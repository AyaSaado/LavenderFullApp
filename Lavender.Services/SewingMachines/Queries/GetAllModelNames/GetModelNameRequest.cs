using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.SewingMachines
{
    public class GetModelNameRequest : IRequest<List<ModelNameDto>>
    {
        public int Id { get; set; }
    }
}
