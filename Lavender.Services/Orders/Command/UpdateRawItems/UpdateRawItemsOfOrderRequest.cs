using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.Orders
{
    public class UpdateRawItemsOfOrderRequest  :IRequest<bool>
    {
        public List<ConsumingDto> ConsumingDtos { get; set; } = new List<ConsumingDto>();

    }
}
