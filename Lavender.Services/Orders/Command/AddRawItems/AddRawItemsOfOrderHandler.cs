using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Orders
{
    public class AddRawItemsOfOrderHandler : IRequestHandler<AddRawItemsOfOrderRequest, bool>
    {
        private readonly ICRUDRepository<Consuming> _consumingRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddRawItemsOfOrderHandler(ICRUDRepository<Consuming> consumingRepository, IUnitOfWork unitOfWork)
        {
            this._consumingRepository = consumingRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddRawItemsOfOrderRequest request, CancellationToken cancellationToken)
        {
            var entities = Mapping.Mapper.Map<List<Consuming>>(request.ConsumingDtos);

            try
            {
                await _consumingRepository.AddRangeAsync(entities);
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
