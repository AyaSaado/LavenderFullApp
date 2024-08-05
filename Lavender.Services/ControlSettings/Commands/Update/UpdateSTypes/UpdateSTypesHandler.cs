using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.ControlSettings
{
    public class UpdateSTypesHandler : IRequestHandler<UpdateSTypesRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<SType> _sTypeRepository;

        public UpdateSTypesHandler(ICRUDRepository<SType> sTypeRepository, IUnitOfWork unitOfWork)
        {
            _sTypeRepository = sTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateSTypesRequest request, CancellationToken cancellationToken)
        {
            var a = request.STypeDtos.Select(f => f.Id);
            var entities = await _sTypeRepository.Find(d => a.Contains(d.Id))
                                                     .ToListAsync(cancellationToken);

            if (entities.Count() < request.STypeDtos.Count())
            {
                return false;
            }

            foreach (var e in request.STypeDtos)
            {
                Mapping.Mapper.Map(e, entities.Find(x => x.Id == e.Id));
            }

            try
            {
                _sTypeRepository.UpdateRange(entities);
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
