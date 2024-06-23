using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Designs
{
    public class UpdateDesignHandler : IRequestHandler<UpdateDesignRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDesignHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateDesignRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Designs.GetOneAsync(d => d.Id == request.Id, cancellationToken);

            if (entity == null) return Result.Failure(new Error("404" , "Entity Not Found"));

            entity.Update(request.Title, request.Height, request.Discount,
                             request.ProductionLineId, request.TailorId
                                      , request.DesignerId);


            entity.DesignImages = Mapping.Mapper.Map<List<DesignImage>>(request.DesignImageDtos);
            entity.Accessories = Mapping.Mapper.Map<List<DesignAccessory>>(request.DesignAccessoryDtos);
            entity.Fabrics = Mapping.Mapper.Map<List<FabricDesign>>(request.FabricDesignDtos);


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
