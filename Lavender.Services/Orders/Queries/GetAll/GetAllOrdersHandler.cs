using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.Orders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersRequest, List<OrdersResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllOrdersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<OrdersResponse>> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Orders.Find(o => o.ActorId == request.ActorId
                                                        && (o.OrderState == request.OrderState))
                                                 .Select(OrdersResponse.Selector())
                                                 .ToListAsync(cancellationToken);

            foreach (var order in orders)
            {
                var entity = await _unitOfWork.Orders.GetOneAsync(o => o.Id == order.Id, cancellationToken);

                if (order.GalleryDesignId != 0)
                {
                    var design = await _unitOfWork.Designs.GetOneAsync(d => d.Id == order.GalleryDesignId, cancellationToken);
                    
                    order.DesignPrice = design!.DesignPrice - design.DesignPrice * (design.Discount / 100);

                    order.ItemsCount = entity!.ItemSizes.SelectMany(i => i.ItemSizeWithColors).Sum(i => i.Amount);
                  
                    order.TotalPrice = order.DesignPrice * order.ItemsCount;
                }
            }

            return orders;
            
        }
    }
}
