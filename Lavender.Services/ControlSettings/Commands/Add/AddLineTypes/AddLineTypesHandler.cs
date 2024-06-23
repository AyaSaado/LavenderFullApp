
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class AddLineTypesHandler : IRequestHandler<AddLineTypesRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<LineType> _lineTyperepository;

        public AddLineTypesHandler(IUnitOfWork unitOfWork, ICRUDRepository<LineType> lineTyperepository)
        {
            _unitOfWork = unitOfWork;
            _lineTyperepository = lineTyperepository;
        }

        public async  Task<bool> Handle(AddLineTypesRequest request, CancellationToken cancellationToken)
        {
            var entities = new List<LineType>();

            foreach (var entity in request.LineTypesName)
            {
                entities.Add(new LineType() { Name = entity });
            }

            try
            {
                await _lineTyperepository.AddRangeAsync(entities);
                await _unitOfWork.Save(cancellationToken);

                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
