using Lavender.Core.Entities;
using Lavender.Core.Enum;
using Lavender.Core.Interfaces.Files;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Designs
{
    public class AddDesignHandler : IRequestHandler<AddDesignRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileServices _fileServices;
        public AddDesignHandler(IUnitOfWork unitOfWork, IFileServices fileServices)
        {
            _unitOfWork = unitOfWork;
            _fileServices = fileServices;
        }

        public async Task<bool> Handle(AddDesignRequest request, CancellationToken cancellationToken)
        {
            foreach(var image in request.DesignImageDtos)
            {
                image.Url = await _fileServices.Upload(image.Image);
            }

            var design = new Design()
            {
                Description = request.Description,
                DesignerId = request.DesignerId,
                Height = request.Height,
                OrderId = request.OrderId,
                DesignPrice = request.DesignPrice,
                Discount = request.Discount,
                DesignImages = Mapping.Mapper.Map<List<DesignImage>>(request.DesignImageDtos),
             
            };

            var order = await _unitOfWork.Orders.GetOneAsync(o => o.Id == design.OrderId, cancellationToken);
            
            order!.OrderState = OrderState.underway;

            try
            {
                _unitOfWork.Orders.Update(order);
                
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
