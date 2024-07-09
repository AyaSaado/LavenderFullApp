using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.ControlSettings
{
    public class UpdateStoreItemsHandler : IRequestHandler<UpdateStoreItemsRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<StoreItem> _accessoryRepository;
  

        public UpdateStoreItemsHandler(ICRUDRepository<StoreItem> accessoryRepository, IUnitOfWork unitOfWork)
        {
            _accessoryRepository = accessoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateStoreItemsRequest request, CancellationToken cancellationToken)
        {
            var a = request.StoreItemDtos.Select(f => f.Id);
            var entities = await _accessoryRepository.Find(d => a.Contains(d.Id))
                                                            .ToListAsync(cancellationToken);

            if (entities.Count() < request.StoreItemDtos.Count())
            {
                return false;
            }
            foreach(var e in request.StoreItemDtos) 
            {
                Mapping.Mapper.Map(e,entities.Find(x => x.Id == e.Id));
            }

            try
            {

                _accessoryRepository.UpdateRange(entities);
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
