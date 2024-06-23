using Lavender.Core.Interfaces.Repository;
using MediatR;

namespace Lavender.Services.ControlSettings
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
            var entity = await _unitOfWork.DesignSections.GetOneAsync(d => d.Id == request.Id ,cancellationToken);

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
