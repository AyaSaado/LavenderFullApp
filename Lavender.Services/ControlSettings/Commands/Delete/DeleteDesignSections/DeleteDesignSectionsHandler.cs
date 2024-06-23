using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
{
    public class DeleteDesignSectionsHandler : IRequestHandler<DeleteDesignSectionsRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDesignSectionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteDesignSectionsRequest request, CancellationToken cancellationToken)
        {
           var entities  = await _unitOfWork.DesignSections.Find(d=> request.Ids.Contains(d.Id))
                                                          .ToListAsync(cancellationToken);

            try
            {
                _unitOfWork.DesignSections.RemoveRange(entities);
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
