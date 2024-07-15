using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Orders
{
    public class GetConsumingDetailsHandler : IRequestHandler<GetConsumingDetailsRequest, List<ConsumingDto>?>
    {
        private readonly IUnitOfWork  _unitOfWork;

        public GetConsumingDetailsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ConsumingDto>?> Handle(GetConsumingDetailsRequest request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetOneAsync(o => o.Id == request.OrderId, cancellationToken);

            if (order == null)
                return null;

                return Mapping.Mapper.Map<List<ConsumingDto>?>(order.Consumings);
        }
    }
}
