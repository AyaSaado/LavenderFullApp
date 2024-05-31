using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;

namespace Lavender.Services.ControlSettings.Commands.Add.AddtemTypes
{
    public class AddItemTypesHandler : IRequestHandler<AddItemTypesRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<ItemType> _itemTypeRepository;

        public AddItemTypesHandler(ICRUDRepository<ItemType> itemTypeRepository, IUnitOfWork unitOfWork)
        {
            _itemTypeRepository = itemTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddItemTypesRequest request, CancellationToken cancellationToken)
        {
            var entities = new List<ItemType>();

            foreach (var name in request.TypesName)
            {
                entities.Add(new ItemType() { Name = name });
            }

            try
            {
                await _itemTypeRepository.AddRangeAsync(entities);
                await _unitOfWork.Save(cancellationToken);
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
