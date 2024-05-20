using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;

namespace Lavender.Services.ControlSettings.Commands.Update.UpdateLineTypes
{
    public class UpdateLineTypeHandler : IRequestHandler<UpdateLineTypeRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<LineType> _lineTyperepository;
        public UpdateLineTypeHandler(IUnitOfWork unitOfWork, ICRUDRepository<LineType> lineTyperepository)
        {
            _unitOfWork = unitOfWork;
            _lineTyperepository = lineTyperepository;
        }

        public async Task<bool> Handle(UpdateLineTypeRequest request, CancellationToken cancellationToken)
        {
            var entity = await _lineTyperepository.GetOneAsync(l => l.Id == request.Id);
           
            if (entity == null)
            {
                return false;
            }
            entity.Name = request.LineTypeName;
           
            _lineTyperepository.Update(entity);
            await _unitOfWork.Save(cancellationToken);

            return true;
        }
    }
}
