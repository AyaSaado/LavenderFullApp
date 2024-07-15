

using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.Orders
{
    public class GetConsumingDetailsRequest  : IRequest<List<ConsumingDto>?>
    {
        public int OrderId { get; set; }
    }
}
