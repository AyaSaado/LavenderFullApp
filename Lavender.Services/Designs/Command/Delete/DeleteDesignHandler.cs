
using Lavender.Core.Interfaces.Repository;
using MediatR;

namespace Lavender.Services.Designs
{
    public class DeleteDesignHandler : IRequestHandler<DeleteDesignRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDesignHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteDesignRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Designs.GetOneAsync(d => d.Id == request.DesignId, cancellationToken);  
       
            if(entity is null)
                return false;

            _unitOfWork.Designs.Remove(entity);
            await _unitOfWork.Save(cancellationToken);

            return true;

        
        }
    }
}
