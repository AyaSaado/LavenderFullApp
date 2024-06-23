using AutoMapper;
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.ControlSettings
{
    public class UpdateAccessoriesHandler : IRequestHandler<UpdateAccessoriesRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<Accessory> _accessoryRepository;
        private readonly IMapper _mapper;

        public UpdateAccessoriesHandler(ICRUDRepository<Accessory> accessoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _accessoryRepository = accessoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateAccessoriesRequest request, CancellationToken cancellationToken)
        {
            var a = request.Accessories.Select(f => f.Id);
            var entities = await _accessoryRepository.Find(d => a.Contains(d.Id))
                                                            .ToListAsync(cancellationToken);

            if (entities.Count() < request.Accessories.Count())
            {
                return false;
            }

            foreach (var accessory in request.Accessories)
            {
                var existingEntity = entities.FirstOrDefault(e => e.Id == accessory.Id);
                if (existingEntity != null)
                {
                    Mapping.Mapper.Map(accessory, existingEntity);
                }
            }

            try
            {
                // _mapper.Map(request.Accessories,entities);

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
