using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdRequest, ItemDto?>
    {

        private readonly ICRUDRepository<Item> _itemRepository;

        public GetItemByIdHandler(ICRUDRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ItemDto?> Handle(GetItemByIdRequest request, CancellationToken cancellationToken)
        {
         
            return  await _itemRepository.Find(it => it.Id == request.ItemId)
                                         .Select(ItemDto.Selector())
                                         .FirstOrDefaultAsync(cancellationToken);

        }
    }
}
