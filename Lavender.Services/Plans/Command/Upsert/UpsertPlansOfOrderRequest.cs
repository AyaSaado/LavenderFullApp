

using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.Plans
{
    public class UpsertPlansOfOrderRequest : IRequest<bool>
    {
        public List<OrderPlans> OrderPlans { get; set; } = new List<OrderPlans>();       
    }
    public class OrderPlans
    {
        public int ItemSizeId { get; set; }
        public List<PlanDto> PlanDtos { get; set; } = new List<PlanDto>();
     }
}
