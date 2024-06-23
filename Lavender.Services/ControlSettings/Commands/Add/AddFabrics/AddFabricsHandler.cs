
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class AddFabricsHandler : IRequestHandler<AddFabricsRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<FabricType> _fabricTypeRepository;

        public AddFabricsHandler(ICRUDRepository<FabricType> fabricTypeRepository, IUnitOfWork unitOfWork)
        {
            _fabricTypeRepository = fabricTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddFabricsRequest request, CancellationToken cancellationToken)
        {
            var entities = new List<FabricType>();

            foreach (var name in request.FabricTypesName)
            {
                entities.Add(new FabricType() { Name = name });
            }

            try
            {
                await _fabricTypeRepository.AddRangeAsync(entities);
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
