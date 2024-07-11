
using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.Plans
{
    public class GetProductionStepByIdRequest : IRequest<ControlData>
    {
        public int ProductionStepId { get; set; }
    }
}
