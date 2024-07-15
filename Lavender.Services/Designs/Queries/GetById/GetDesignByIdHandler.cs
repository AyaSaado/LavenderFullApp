using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Designs
{
    public class GetDesignByIdHandler : IRequestHandler<GetDesignByIdRequest, OneDesignResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDesignByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneDesignResponse?> Handle(GetDesignByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Designs.Find(d => d.Id == request.Id)
                                            .Select(OneDesignResponse.Selector())
                                            .FirstOrDefaultAsync(cancellationToken);

           
            if (result is not null)
            {
                var order = await _unitOfWork.Orders.GetOneAsync(o => o.Id == result.OrderId, cancellationToken);
                
                result.ItemSizeDtos = Mapping.Mapper.Map<List<ItemSizeDto>>(order!.ItemSizes);

                result.UsedFabrics =  order.Consumings
                                            .Select(c => c.SItemType)
                                            .Where(s => s.StoreItem.Name.Equals("Fabric"))
                                            .Select(s => s.SType.Name)
                                            .ToList();
              
                result.OrdersOfDesignCount = await _unitOfWork.Orders.Find(o => o.GalleryDesignId == result.Id)
                                                                     .CountAsync(cancellationToken);
            }      
    
            return result;
        }
    }
}
