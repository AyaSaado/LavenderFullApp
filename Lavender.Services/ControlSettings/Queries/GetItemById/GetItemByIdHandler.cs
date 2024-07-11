using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdRequest, ItemResponse?>
    {

        private readonly ICRUDRepository<Item> _itemRepository;

        public GetItemByIdHandler(ICRUDRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ItemResponse?> Handle(GetItemByIdRequest request, CancellationToken cancellationToken)
        {
         
            return  await _itemRepository.Find(it => it.Id == request.ItemId)
                                         .Select(ItemResponse.Selector())
                                         .FirstOrDefaultAsync(cancellationToken);

        }
    }
}
