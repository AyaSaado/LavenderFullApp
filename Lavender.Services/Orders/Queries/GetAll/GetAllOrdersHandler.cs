using Lavender.Core.Entities;
using Lavender.Core.Enum;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.Orders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersRequest, List<OrdersResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<Step> _stepRepository;

        public GetAllOrdersHandler(IUnitOfWork unitOfWork, ICRUDRepository<Step> stepRepository)
        {
            _unitOfWork = unitOfWork;
            _stepRepository = stepRepository;
        }

        public async Task<List<OrdersResponse>> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Orders.Find(o => (request.ActorId == Guid.Empty || o.ActorId == request.ActorId )&&
                                                            (request.ProductionId == Guid.Empty || o.ProductionLineId == request.ProductionId)
                                                        &&  ( request.All  || (o.OrderState == request.OrderState))
                                                        &&  (request.CustomOrder ? o.OrderType.Equals(Ordertype.custom): true )
                                                        && ((request.ItemId == 0) || (o.ItemId == request.ItemId)) &&
                                                           ((request.ItemTypeId == 0) || (o.ItemTypeId == request.ItemTypeId)))
                                                 .OrderByDescending(o=>o.OrderDate)   
                                                 .Select(OrdersResponse.Selector())
                                                 .ToListAsync(cancellationToken);

            foreach (var order in orders)
            {
                var entity = await _unitOfWork.Orders.GetOneAsync(o => o.Id == order.Id, cancellationToken);

                order.ItemsCount = entity!.ItemSizes.SelectMany(i => i.ItemSizeWithColors).Sum(i => i.Amount);

                var lastStep = await _stepRepository.GetOneAsync(s => s.Name == "Done", cancellationToken);

                order.CompletedItemsCount = entity.ItemSizes.SelectMany(i => i.Plans)
                                                            .Where(p => p.StepId == lastStep!.Id)
                                                            .Sum(p => p.Amount); 

                if (order.GalleryDesignId != 0)
                {
                    var design = await _unitOfWork.Designs.GetOneAsync(d => d.Id == order.GalleryDesignId, cancellationToken);

                    if (design is null)
                        return orders;

                    order.DesignPrice = design.DesignPrice - design.DesignPrice * (design.Discount / 100);
 
                    order.TotalPrice = order.DesignPrice * order.ItemsCount;
                }
            }

            return orders;
            
        }
    }
}
