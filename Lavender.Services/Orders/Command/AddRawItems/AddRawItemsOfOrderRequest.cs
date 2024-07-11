using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.Orders
{
    public class AddRawItemsOfOrderRequest : IRequest<bool>
    {
      public List<ConsumingDto> ConsumingDtos {  get; set; } = new List<ConsumingDto>();

    }
}
