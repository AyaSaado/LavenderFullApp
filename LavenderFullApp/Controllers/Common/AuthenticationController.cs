using Lavender.Core.EntityDto;
using Lavender.Core.Shared;
using Lavender.Services.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace LavenderFullApp.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Common")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AuthenticationController> _localization;
        public AuthenticationController(IMediator mediator, IStringLocalizer<AuthenticationController> localization)
        {
            _mediator = mediator;
            _localization = localization;
        }


        [HttpPost("Login")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<TokenDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromQuery] TokenRequest.Request command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(_localization[result.Error.Message]);
        }


        [HttpPost("RefreshToken")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<TokenDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpPost("AddUser(Register)")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddUser([FromForm] AddUserRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok() : BadRequest(_localization[result.Error.Message]);
        }

        [HttpGet("ForgetPassword")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ForgetPassword([FromQuery] ForgetPasswordRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);

            return result.IsNullOrEmpty() ? BadRequest() : Ok(result);
        }


    }
}
