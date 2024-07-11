using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
{
    public class GetItemDetailsHandler : IRequestHandler<GetItemDetailsRequest, List<ItemDetailResponse>>
    {
        private readonly ICRUDRepository<SItemType> _sItemTypeRepository;

        public GetItemDetailsHandler(ICRUDRepository<SItemType> sItemTypeRepository)
        {
            _sItemTypeRepository = sItemTypeRepository;
        }

        public async Task<List<ItemDetailResponse>> Handle(GetItemDetailsRequest request, CancellationToken cancellationToken)
        {
            return await _sItemTypeRepository.GetAll()
                                             .Select(ItemDetailResponse.Selector())
                                             .ToListAsync(cancellationToken);
        }
    }
}
