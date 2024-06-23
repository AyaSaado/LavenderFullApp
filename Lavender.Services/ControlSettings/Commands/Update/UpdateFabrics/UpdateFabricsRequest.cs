
using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class UpdateFabricsRequest : IRequest<bool>
    {
        public List<ControlData> FabricTypes { get; set; } = new List<ControlData>();
    }


}
