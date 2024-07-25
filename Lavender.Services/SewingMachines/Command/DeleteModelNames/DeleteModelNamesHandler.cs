
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.SewingMachines
{
    public class DeleteModelNamesHandler : IRequestHandler<DeleteModelNamesRequest, bool>
    {
        private readonly ICRUDRepository<ModelName> _modelNameRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModelNamesHandler(IUnitOfWork unitOfWork, ICRUDRepository<ModelName> modelNameRepository)
        {
            _unitOfWork = unitOfWork;
            _modelNameRepository = modelNameRepository;
        }

        public async Task<bool> Handle(DeleteModelNamesRequest request, CancellationToken cancellationToken)
        {
            var entities = await _modelNameRepository.Find(s => request.Ids.Contains(s.Id))
                                                         .ToListAsync(cancellationToken);
            if(request.Ids.Count != entities.Count)
            {
                return false;
            }

            try
            {
                _modelNameRepository.RemoveRange(entities);
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
