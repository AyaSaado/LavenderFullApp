using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Services.ControlSettings.Queries.GetAllItemTypes.GetAllItemTypesRequest;

namespace Lavender.Services.ControlSettings.Queries.GetAllItemTypes
{
    public class GetAllItemTypesHandler : IRequestHandler<GetAllItemTypesRequest, List<ItemTypesResponse>>
    {

        private readonly ICRUDRepository<ItemType> _itemTypeRepository;

        public GetAllItemTypesHandler(ICRUDRepository<ItemType> itemTyperepository)
        {
            _itemTypeRepository = itemTyperepository;
        }

        public async Task<List<ItemTypesResponse>> Handle(GetAllItemTypesRequest request, CancellationToken cancellationToken)
        {
            var result = await _itemTypeRepository.GetAll()
                                                  .Select(ItemTypesResponse.Selector())
                                                  .ToListAsync(cancellationToken);
            return result;
        }
    }
}
