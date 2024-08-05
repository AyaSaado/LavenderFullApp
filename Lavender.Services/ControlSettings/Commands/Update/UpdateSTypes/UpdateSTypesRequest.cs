using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class UpdateSTypesRequest : IRequest<bool>
    {
        public List<ControlData> STypeDtos { get; set; } = new List<ControlData>();

    }
}
