using Lavender.Services.Orders.Command.AddFeedBack;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LavenderFullApp.Controllers.DashBoard
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "DashBoard")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("AddFeedBack")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] AddFeedBackRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : BadRequest();
        }

    }
}
