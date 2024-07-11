

using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.Plans
{
    public class UpsertPlansOfOrderRequest : IRequest<bool>
    {
        public int ItemSizeId { get; set; }
        public List<PlanDto> PlanDtos { get; set; } = new List<PlanDto>();
    }
  
}
