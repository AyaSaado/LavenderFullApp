using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.Orders
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, Result<OrderResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrderByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<OrderResponse>> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.Find(o => o.Id == request.OrderId)
                                                .Select(OrderResponse.Selector())
                                                .FirstOrDefaultAsync(cancellationToken);
            if (order == null) 
            {
                return Result.Failure<OrderResponse>(new Error("404", "Order Is Not Found"));
            }

            if (order.GalleryDesignId != 0)
            {
                var design = await _unitOfWork.Designs.GetOneAsync(d => d.Id == order.GalleryDesignId, cancellationToken);
                order.DesignPrice = design!.DesignPrice - design.DesignPrice * (design.Discount / 100);
            }

            order.UsedFabrics = await _unitOfWork.Orders.Find(o => o.Id == order.Id)
                                            .SelectMany(o => o.Consumings)
                                            .Select(c => c.SItemType)
                                            .Where(s => s.StoreItem.Name.Equals("Fabric"))
                                            .Select(s => s.SType.Name)
                                            .ToListAsync(cancellationToken);

            return order;
        }
    }
}
