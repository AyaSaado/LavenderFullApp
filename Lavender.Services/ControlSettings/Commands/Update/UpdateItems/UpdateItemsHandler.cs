using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class UpdateItemsHandler : IRequestHandler<UpdateItemsRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<Item> _itemRepository;

        public UpdateItemsHandler(ICRUDRepository<Item> itemRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateItemsRequest request, CancellationToken cancellationToken)
        {
            var entities = new List<Item>();

            foreach (var item in request.Items)
            {
                var i = await _itemRepository.GetOneAsync(i => i.Id == item.Id, cancellationToken);
                
                if (i is null) return false;

                i.Name = item.Name;
                i.Discount = item.Discount;
                entities.Add(i);
            }

            try
            {
                 _itemRepository.UpdateRange(entities);
                await _unitOfWork.Save(cancellationToken);
                return true;

            }catch(Exception)
            {
                return false;
            }

        }
    }
}
