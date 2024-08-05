using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class AddItemsHandler : IRequestHandler<AddItemsRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<Item> _itemRepository;

        public AddItemsHandler(ICRUDRepository<Item> itemRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddItemsRequest request, CancellationToken cancellationToken)
        {
            var entities = new List<Item>();

            foreach (var item in request.Items)
            {
                entities.Add(new Item() { Name = item.Name , Discount = item.Discount });
            }

            try
            {
                await _itemRepository.AddRangeAsync(entities);
                await _unitOfWork.Save(cancellationToken);
                return true;

            }catch(Exception)
            {
                return false;
            }

        }
    }
}
