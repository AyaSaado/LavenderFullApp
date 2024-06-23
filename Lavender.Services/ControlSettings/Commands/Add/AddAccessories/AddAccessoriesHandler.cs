
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class AddAccessoriesHandler : IRequestHandler<AddAccessoriesRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<Accessory> _accessoryRepository;

        public AddAccessoriesHandler(ICRUDRepository<Accessory> accessoryRepository, IUnitOfWork unitOfWork)
        {
            _accessoryRepository = accessoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddAccessoriesRequest request, CancellationToken cancellationToken)
        {
            var entities = new List<Accessory>();

            foreach (var name in request.AccessoriesName)
            {
                entities.Add(new Accessory() { Name = name });
            }

            try
            {
                await _accessoryRepository.AddRangeAsync(entities);
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
