using Lavender.Services.Orders.Queries.GetAll;
using Lavender.Services.Orders.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static Lavender.Services.Orders.Queries.GetAll.GetAllOrdersRequest;
using static Lavender.Services.Orders.Queries.GetById.GetOrderByIdRequest;

namespace LavenderFullApp.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Common")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllOrders")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(OrdersResponse))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllOrdersRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetOrderById")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(OrderResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromQuery] GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result.IsSuccess ?  Ok(result.Value) : NotFound(result.Error);
        }
    }
}
