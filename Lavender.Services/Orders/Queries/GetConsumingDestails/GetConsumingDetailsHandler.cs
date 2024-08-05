using Lavender.Core.EntityDto;
using Lavender.Core.Enum;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var orders = await _unitOfWork.Orders.Find(o => (o.Id == request.OrderId) ||( request.OrderId == 0 && o.OrderState == OrderState.underway))
                                                 .ToListAsync(cancellationToken);

            if (orders == null)
                return null;

            var consumings = orders.SelectMany(o => o.Consumings)
                                   .OrderByDescending(c => c.DateOfDemand)
                                   .ToList();

            return Mapping.Mapper.Map<List<ConsumingDto>>(consumings);

        }
    }
}
