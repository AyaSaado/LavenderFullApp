using Lavender.Services.Orders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LavenderFullApp.Controllers.MobileApp
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "MobileApp")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
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
