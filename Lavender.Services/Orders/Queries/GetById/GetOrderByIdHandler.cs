using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using MailKit.Search;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.Orders
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, Result<OrderResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<Step> _stepRepository;

        public GetOrderByIdHandler(IUnitOfWork unitOfWork, ICRUDRepository<Step> stepRepository)
        {
            _unitOfWork = unitOfWork;
            _stepRepository = stepRepository;
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
                order.ItemsCount = order.ItemSizeDtos.SelectMany(i => i.ItemSizeWithColorDtos).Sum(i => i.Amount);
                
                var entity = await _unitOfWork.Orders.GetOneAsync(o => o.Id == order.Id, cancellationToken);

                var lastStep = await _stepRepository.GetOneAsync(s => s.Name == "Done", cancellationToken);

               order.CompletedItemsCount = entity!.ItemSizes.SelectMany(i => i.Plans)
                                                        .Where(p => p.StepId == lastStep!.Id)
                                                        .Sum(p => p.Amount);
            if (order.GalleryDesignId != 0)
            {
                var design = await _unitOfWork.Designs.GetOneAsync(d => d.Id == order.GalleryDesignId, cancellationToken);
             
                if (design is null)
                    return order;

                order.DesignPrice = design.DesignPrice - design.DesignPrice * (design.Discount / 100);
                
                order.TotalPrice = order.DesignPrice * order.ItemsCount;

                order.UsedFabrics = await _unitOfWork.Orders.Find(o => o.Id == design.OrderId)
                                           .SelectMany(o => o.Consumings)
                                           .Select(c => c.SItemType)
                                           .Where(s => s.StoreItem.Name.Equals("Fabric"))
                                           .Select(s => s.SType.Name)
                                           .ToListAsync(cancellationToken);


            }
            else
            {
                order.UsedFabrics = await _unitOfWork.Orders.Find(o => o.Id == order.Id)
                                           .SelectMany(o => o.Consumings)
                                           .Select(c => c.SItemType)
                                           .Where(s => s.StoreItem.Name.Equals("Fabric"))
                                           .Select(s => s.SType.Name)
                                           .ToListAsync(cancellationToken);
            }
        

            return order;
        }
    }
}
