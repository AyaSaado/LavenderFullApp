
using Lavender.Core.Interfaces.Files;
using Lavender.Core.Interfaces.Repository;
using MediatR;

namespace Lavender.Services.Designs
{
    public class DeleteDesignHandler : IRequestHandler<DeleteDesignRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileServices _fileServices;

        public DeleteDesignHandler(IUnitOfWork unitOfWork, IFileServices fileServices)
        {
            _unitOfWork = unitOfWork;
            _fileServices = fileServices;
        }

        public async Task<bool> Handle(DeleteDesignRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Designs.GetOneAsync(d => d.Id == request.DesignId, cancellationToken);  
       
            if(entity is null)
                return false;

            _fileServices.Delete(entity.DesignImages.Select(i => i.Url).ToList());
           
            _unitOfWork.Designs.Remove(entity);
            await _unitOfWork.Save(cancellationToken);

            return true;

        
        }
    }
}
