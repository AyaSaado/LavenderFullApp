using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Enum;
using MediatR;
using System.Linq.Expressions;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Plans
{
    public class GetPlansOfOrderRequest : IRequest<List<PlanOfOrderResponse>>
    {
        public int OrderId { get; set; }    
    }

    public class PlanOfOrderResponse
    {
        public int Id { get; set; }
        public Size Size { get; set; }
        public List<PlanDto> PlanDtos { get; set; } = new List<PlanDto>();

        public static Expression<Func<ItemSize, PlanOfOrderResponse>> Selector() => c
            => new()
            {
                Id = c.Id,
                Size = c.Size,
                PlanDtos = Mapping.Mapper.Map<List<PlanDto>>(c.Plans) 
            };
    }
}
