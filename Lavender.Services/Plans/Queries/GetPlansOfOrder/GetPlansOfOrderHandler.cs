
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.Plans
{
    public class GetPlansOfOrderHandler : IRequestHandler<GetPlansOfOrderRequest, List<PlanOfOrderResponse>>
    {
        public readonly ICRUDRepository<ItemSize> _itemSizeRepository;

        public GetPlansOfOrderHandler(ICRUDRepository<ItemSize> itemSizeRepository)
        {
            _itemSizeRepository = itemSizeRepository;
        }

        public async Task<List<PlanOfOrderResponse>> Handle(GetPlansOfOrderRequest request, CancellationToken cancellationToken)
        {
            var result = await _itemSizeRepository.Find(i=>i.OrderId == request.OrderId)
                                                 //.Include(i=>i.Plans)
                                                 .Select(PlanOfOrderResponse.Selector())
                                                 .ToListAsync(cancellationToken);

            return result;
        }
    }
}
