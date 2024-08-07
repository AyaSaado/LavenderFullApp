﻿using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Lavender.Services.ControlSettings
{
    public class GetAllItemsHandler : IRequestHandler<GetAllItemsRequest, List<ItemDto>>
    {

        private readonly ICRUDRepository<Item> _itemRepository;

        public GetAllItemsHandler(ICRUDRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<ItemDto>> Handle(GetAllItemsRequest request, CancellationToken cancellationToken)
        {
            var result = await _itemRepository.Find(i=> (request.ItemName.IsNullOrEmpty() || i.Name.StartsWith(request.ItemName!)) )
                                                  .Select(ItemDto.Selector())
                                                  
                                                  .ToListAsync(cancellationToken);
            return result;
        }
    }
}
