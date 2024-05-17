using Lavender.Core.EntityDto;
using Lavender.Core.Shared;
using Lavender.Services.PatternMakers.Commands.Update;
using Lavender.Services.ProductionEmps.Commands.Update;
using Lavender.Services.Users.Commands.Add;
using Lavender.Services.Users.Commands.Delete;
using Lavender.Services.Users.Commands.ForgetPassword;
using Lavender.Services.Users.Commands.Login;
using Lavender.Services.Users.Commands.RefreshToken;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace LavenderFullApp.Controllers.Common
{
    [ApiExplorerSettings(GroupName = "Common")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<TokenDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromQuery] TokenRequest.Request command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpPost("RefreshToken")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<TokenDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }


        [HttpGet("ForgetPassword")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ForgetPassword([FromQuery] ForgetPasswordRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);

            return result.IsNullOrEmpty() ? BadRequest() : Ok(result);
        }


        [HttpPost("AddUser(Register)")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<UserDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpDelete("DeleteUser")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<UserDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody] DeleteUserRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        [HttpPut("UpdatePatternMaker")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<PatternMakerDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdatePatternMakerRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpPut("UpdateProductionEmp")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<ProductionEmpDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateProductionEmpRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

    }
}
