
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Plans
{
    public class UpsertPlansOfOrderHandler : IRequestHandler<UpsertPlansOfOrderRequest, bool>
    {
        private readonly ICRUDRepository<ItemSize> _itemSizeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertPlansOfOrderHandler(ICRUDRepository<ItemSize> itemSizeRepository, IUnitOfWork unitOfWork)
        {
            _itemSizeRepository = itemSizeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpsertPlansOfOrderRequest request, CancellationToken cancellationToken)
        {
            var entity = await _itemSizeRepository.GetOneAsync(i => i.Id == request.ItemSizeId, cancellationToken);
            
            if(entity is null)
                return false;

            Mapping.Mapper.Map(request.PlanDtos, entity.Plans);

            try
            {
                _itemSizeRepository.Update(entity);
                await _unitOfWork.Save(cancellationToken);

                return true;
            }
           catch(Exception)
            {
                return false;
            }
        }
    }
}
