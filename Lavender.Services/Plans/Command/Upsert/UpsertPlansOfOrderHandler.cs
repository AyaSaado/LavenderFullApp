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
            var updatedEntities = new List<ItemSize>();
   
            foreach(var entity in request.OrderPlans)
            {
                var x = await _itemSizeRepository.GetOneAsync(i=>i.Id == entity.ItemSizeId, cancellationToken);
                
                if (x is null)
                    return false;

                Mapping.Mapper.Map(entity.PlanDtos, x.Plans);

                updatedEntities.Add(x);
            }
            try
            {
                _itemSizeRepository.UpdateRange(updatedEntities);
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
