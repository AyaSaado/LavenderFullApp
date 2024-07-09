using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.ControlSettings
{
    public class AddItemDetailsHandler : IRequestHandler<AddItemDetailsRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<SItemType> _sItemTypeRepository;

        public AddItemDetailsHandler(ICRUDRepository<SItemType> sItemTypeRepository, IUnitOfWork unitOfWork)
        {
            _sItemTypeRepository = sItemTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddItemDetailsRequest request, CancellationToken cancellationToken)
        {
            var entities = new List<SItemType>();

           foreach(var e in request.ItemDetailsRequest)
           {
                var stype = Mapping.Mapper.Map<SType>(e.stype);
                entities.Add(new SItemType()
                {
                    Color = e.Color,
                    Amount = e.Amount,
                    StoreItemId = e.StoreItemId,
                    MinAmount = e.MinAmount
                });

                if(stype.Id == 0)
                {
                    entities.Last().SType = stype;
                }
                else
                {
                    entities.Last().STypeId = stype.Id;
                }
           }

            try
            {
                await _sItemTypeRepository.AddRangeAsync(entities);
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
