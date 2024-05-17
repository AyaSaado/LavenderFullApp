using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using Lavender.Services.DesignSections.Commands.Add;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.DesignSections.Commands.Update
{
    public class UpdateDesignSectionHandler : IRequestHandler<UpdateDesignSectionRequest, Result<DesignSectionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDesignSectionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DesignSectionDto>> Handle(UpdateDesignSectionRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.DesignSections.GetOneAsync(d=>d.Id == request.Id);

            if(entity == null)
            {
                return Result.Failure<DesignSectionDto>(new Error("404", "Entity Is Not Found"));
            }

            entity.Name = request.DesignSectionName;

            try
            {
                _unitOfWork.DesignSections.Update(entity);
                await _unitOfWork.Save(cancellationToken);
                return Mapping.Mapper.Map<DesignSectionDto>(entity);

            }
            catch (Exception)
            {
                return Result.Failure<DesignSectionDto>(new Error("400", "Updating Failed"));
            }
        }
    }
}
