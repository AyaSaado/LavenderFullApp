using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
{
    public class GetItemTypeByIdHandler : IRequestHandler<GetItemTypeByIdRequest, ItemTypesResponse?>
    {

        private readonly ICRUDRepository<ItemType> _itemTypeRepository;

        public GetItemTypeByIdHandler(ICRUDRepository<ItemType> itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }

        public async Task<ItemTypesResponse?> Handle(GetItemTypeByIdRequest request, CancellationToken cancellationToken)
        {
         
            return  await _itemTypeRepository.Find(it => it.Id == request.ItemTypeId)
                                         .Select(ItemTypesResponse.Selector())
                                         .FirstOrDefaultAsync(cancellationToken);

        }
    }
}
