using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings.Commands.Delete.DeleteLineTypes
{
    public class DeleteLineTypesHandler : IRequestHandler<DeleteLineTypesRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<LineType> _lineTyperepository;

        public DeleteLineTypesHandler(ICRUDRepository<LineType> lineTyperepository, IUnitOfWork unitOfWork)
        {
            _lineTyperepository = lineTyperepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteLineTypesRequest request, CancellationToken cancellationToken)
        {
          var entities = await _lineTyperepository.Find(l=> request.Ids.Contains(l.Id))
                                                  .ToListAsync(cancellationToken);

          try
          {
                _lineTyperepository.RemoveRange(entities);
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
