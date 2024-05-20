using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.ControlSettings.Commands.Update.UpdateDesignSections
{
    public class UpdateDesignSectionHandler : IRequestHandler<UpdateDesignSectionRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDesignSectionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateDesignSectionRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.DesignSections.GetOneAsync(d => d.Id == request.Id);

            if (entity == null)
            {
                return false;
            }

            entity.Name = request.DesignSectionName;

            _unitOfWork.DesignSections.Update(entity);
            await _unitOfWork.Save(cancellationToken);

            return true;

         
        }
    }
}
