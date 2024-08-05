using Lavender.Core.EntityDto;
using Lavender.Services.Orders;
using Lavender.Services.Payments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LavenderFullApp.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Common")]
    [Authorize]

    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllOrders")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<OrdersResponse>))]
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

        [HttpGet("GetConsumingDetails")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<ConsumingDto>))]
        public async Task<IActionResult> GetAll([FromQuery] GetConsumingDetailsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetAllPaymentsOfOrder")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<PaymentDto>))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPaymentsOfOrderRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }


        [HttpPost("AddOrder")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] AddOrderRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        [HttpPut("UpdateOrder")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] UpdateOrderRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        [HttpPut("PutLastPriceOfOrder")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] PutLastPriceOfOrderRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        [HttpDelete("DeleteOrder")]
        [SwaggerResponse(StatusCodes.Status204NoContent, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromQuery] DeleteOrderRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? NoContent() : NotFound();
        }
    }
}
