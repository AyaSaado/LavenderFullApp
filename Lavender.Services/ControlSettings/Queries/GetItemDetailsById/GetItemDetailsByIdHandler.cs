using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
{
    public class GetItemDetailsByIdHandler : IRequestHandler<GetItemDetailsByIdRequest, ItemDetailResponse?>
    {
        private readonly ICRUDRepository<SItemType> _sItemTypeRepository;

        public GetItemDetailsByIdHandler(ICRUDRepository<SItemType> sItemTypeRepository)
        {
            _sItemTypeRepository = sItemTypeRepository;
        }

        public async Task<ItemDetailResponse?> Handle(GetItemDetailsByIdRequest request, CancellationToken cancellationToken)
        {
            return await _sItemTypeRepository.Find(i=>i.Id == request.SItemTypeId)
                                             .Select(ItemDetailResponse.Selector())
                                             .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
