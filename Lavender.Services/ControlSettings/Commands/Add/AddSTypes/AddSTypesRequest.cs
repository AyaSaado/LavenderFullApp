using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class AddSTypesRequest : IRequest<bool>
    {
        public List<ControlData> STypeDtos { get; set; } = new List<ControlData>();

    }

}
