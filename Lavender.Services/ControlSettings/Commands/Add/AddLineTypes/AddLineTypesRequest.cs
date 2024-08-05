using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class AddLineTypesRequest : IRequest<bool>
    {
        public List<LineTypeDto> LineTypeDtos { get; set; } = new List<LineTypeDto>();
    }

}
