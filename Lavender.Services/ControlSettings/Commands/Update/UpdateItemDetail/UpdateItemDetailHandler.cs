using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class UpdateItemDetailHandler : IRequestHandler<UpdateItemDetailRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<SItemType> _sItemTypeRepository;

        public UpdateItemDetailHandler(ICRUDRepository<SItemType> sItemTypeRepository, IUnitOfWork unitOfWork)
        {
            _sItemTypeRepository = sItemTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateItemDetailRequest request, CancellationToken cancellationToken)
        {
            var entity = await _sItemTypeRepository.GetOneAsync(d=> d.Id == request.ItemDetail.Id , cancellationToken);

            if (entity is null)
            {
                return false;
            }

            entity.Amount = request.ItemDetail.Amount;
            entity.Color  = request.ItemDetail.Color;
            entity.MinAmount = request.ItemDetail.MinAmount;
            entity.Price = request.ItemDetail.Price;

            try
            {
                _sItemTypeRepository.Update(entity);
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
