using Lavender.Core.EntityDto;
using Lavender.Core.Shared;
using Lavender.Services.Users.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LavenderFullApp.Controllers.DashBoard
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "DashBoard")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("Update")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<UserDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Uodate([FromBody] UpdateUserRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }
       
    }
}
