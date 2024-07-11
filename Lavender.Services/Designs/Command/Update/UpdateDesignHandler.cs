using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Files;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Designs
{
    public class UpdateDesignHandler : IRequestHandler<UpdateDesignRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileServices _fileServices;
        public UpdateDesignHandler(IUnitOfWork unitOfWork, IFileServices fileServices)
        {
            _unitOfWork = unitOfWork;
            _fileServices = fileServices;
        }

        public async Task<Result> Handle(UpdateDesignRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Designs.GetOneAsync(d => d.Id == request.Id, cancellationToken);

            if (entity == null) return Result.Failure(new Error("404" , "Entity Not Found"));

            entity.Update(request.Description, request.Height, request.Discount,
                                  request.DesignPrice,request.TailorId
                                         , request.DesignerId);

            
            foreach (var image in request.DesignImageDtos)
            {
                if (image.Image is not null)
                {
                    _fileServices.Delete(image.Url);
                    image.Url = await _fileServices.Upload(image.Image);
                }
            }

            entity.DesignImages = Mapping.Mapper.Map<List<DesignImage>>(request.DesignImageDtos);

            try
            {
                _unitOfWork.Designs.Update(entity);
                await _unitOfWork.Save(cancellationToken);

                return Result.Success();
            }
            catch(Exception)
            {
                return Result.Failure(new Error("400", "Failed Updating"));
            }

        }
    }
}
