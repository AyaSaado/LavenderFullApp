using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Services.ControlSettings.Queries.GetAllItems.GetAllItemsRequest;
using static Lavender.Services.ControlSettings.Queries.GetAllLineTypes.GetAllLineTypesRequest;

namespace Lavender.Services.ControlSettings.Queries.GetAllItems
{
    public class GetAllItemsHandler : IRequestHandler<GetAllItemsRequest, List<ItemsResponse>>
    {

        private readonly ICRUDRepository<Item> _itemRepository;

        public GetAllItemsHandler(ICRUDRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<ItemsResponse>> Handle(GetAllItemsRequest request, CancellationToken cancellationToken)
        {
            var result = await _itemRepository.GetAll()
                                                  .Select(ItemsResponse.Selector())
                                                  .ToListAsync(cancellationToken);
            return result;
        }
    }
}
