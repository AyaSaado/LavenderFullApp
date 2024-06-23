using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.ControlSettings
{
    public class UpdateFabricsHandler : IRequestHandler<UpdateFabricsRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<FabricType> _fabricTypeRepository;

        public UpdateFabricsHandler(ICRUDRepository<FabricType> fabricTypeRepository, IUnitOfWork unitOfWork)
        {
            _fabricTypeRepository = fabricTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateFabricsRequest request, CancellationToken cancellationToken)
        {
            var entities = await _fabricTypeRepository.Find(d => request.FabricTypes.Select(f => f.Id).Contains(d.Id))
                                                          .ToListAsync(cancellationToken);

            if (entities.Count() < request.FabricTypes.Count())
            {
                return false;
            }

            foreach (var type in request.FabricTypes)
            {
                var existingEntity = entities.FirstOrDefault(e => e.Id == type.Id);
                if (existingEntity != null)
                {
                    Mapping.Mapper.Map(type, existingEntity);
                }
            }
            try
            {
                _fabricTypeRepository.UpdateRange(entities);
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
