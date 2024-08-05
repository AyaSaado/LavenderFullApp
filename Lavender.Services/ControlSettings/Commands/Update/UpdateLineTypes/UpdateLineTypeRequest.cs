using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class UpdateLineTypeRequest : IRequest<bool> 
    {
        public LineTypeDto LineTypeDto { get; set; } = null!;
    }
}
