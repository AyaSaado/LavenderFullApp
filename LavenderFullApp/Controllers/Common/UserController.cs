﻿using Lavender.Core.Shared;
using Lavender.Services.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Lavender.Services.ProductionEmps;
using Lavender.Services.PatternMakers;
using Microsoft.Extensions.Localization;

namespace LavenderFullApp.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Common")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IStringLocalizer<UserController> _localization;
        public UserController(IMediator mediator, IStringLocalizer<UserController> localization)
        {
            _mediator = mediator;
            _localization = localization;
        }



        [HttpPut("UpdateUser")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromForm] UpdateUserRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok() : BadRequest(_localization[result.Error.Message]);
        }


        [HttpDelete("DeleteUser")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody] DeleteUserRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : BadRequest(_localization["Not Allowed To Remove This User"]);
        }

        [HttpPut("UpdatePatternMaker")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromForm] UpdatePatternMakerRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok() : BadRequest(_localization[result.Error.Message]);
        }

        [HttpPost("AddProductionEmp")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromForm] AddProductionEmpRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest(_localization[result.Error.Message]);
        }


        [HttpPut("UpdateProductionEmp")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromForm] UpdateProductionEmpRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok() : BadRequest(_localization[result.Error.Message]);
        }


        [HttpGet("GetAllUsersOfRole")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<AllUserResponse>))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetUserById")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<UserResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetAll([FromQuery] GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }


        [HttpGet("GetAllProductionEmps")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<ProductionEmpResponse>))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductionEmpRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);     
            return Ok(result);
        }

        [HttpGet("GetEmpsOfProductionManager")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<ProductionEmpResponse>))]
        public async Task<IActionResult> GetAll([FromQuery] GetEmpsOfManagerRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }


        [HttpGet("GetProductionEmpById")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<ProductionEmpResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] GetProductionEmpByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }


        [HttpGet("GetAllPatternMakers")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<PatternMakerResponse>))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPatternMakerRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetPatternMakerById")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<PatternMakerResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] GetPatternMakerByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }
    }
}
