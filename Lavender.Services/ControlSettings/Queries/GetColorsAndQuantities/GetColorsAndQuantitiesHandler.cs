
using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Enum;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.ControlSettings
{
    public class GetColorsAndQuantitiesHandler : IRequestHandler<GetColorsAndQuantitiesRequest, List<ColorsAndQuantities>>
    {
        private readonly ICRUDRepository<SItemType> _sItemTypeRepository;

        public GetColorsAndQuantitiesHandler(ICRUDRepository<SItemType> sItemTypeRepository)
        {
            _sItemTypeRepository = sItemTypeRepository;
        }

        public async Task<List<ColorsAndQuantities>> Handle(GetColorsAndQuantitiesRequest request, CancellationToken cancellationToken)
        {
            var sitemtype = await _sItemTypeRepository.GetOneAsync(s => s.Id == request.SItemTypeId, cancellationToken);
          
            return await _sItemTypeRepository.Find(s=>(s.STypeId == sitemtype!.STypeId )&& (s.StoreItemId == sitemtype.StoreItemId))
                                             .Select(s => new ColorsAndQuantities()
                                             {
                                                 Id = s.Id,
                                                 Color = s.Color,
                                                 Quantity = s.Amount
                                             })
                                             .ToListAsync(cancellationToken);
        }
    }
}
