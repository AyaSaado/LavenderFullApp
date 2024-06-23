using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Designs
{
    public class AddDesignHandler : IRequestHandler<AddDesignRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddDesignHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddDesignRequest request, CancellationToken cancellationToken)
        {
            var design = new Design()
            {
                Title = request.Title,
                DesignerId = request.DesignerId,
                Height = request.Height,
                OrderId = request.OrderId,
                DesignImages = Mapping.Mapper.Map<List<DesignImage>>(request.DesignImageDtos),
                Accessories = Mapping.Mapper.Map<List<DesignAccessory>>(request.DesignAccessoryDtos),
                Fabrics = Mapping.Mapper.Map<List<FabricDesign>>(request.FabricDesignDtos),

            };

            try
            {
                await _unitOfWork.Designs.AddAsync(design);
                await _unitOfWork.Save(cancellationToken);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
