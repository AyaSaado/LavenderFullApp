﻿using Lavender.Core.EntityDto;
using Lavender.Core.Shared;
using Lavender.Services.PatternMakers.Commands.Update;
using Lavender.Services.PatternMakers.Queries.GetAll;
using Lavender.Services.PatternMakers.Queries.GetById;
using Lavender.Services.ProductionEmps.Commands.Update;
using Lavender.Services.ProductionEmps.Queries.GetAll;
using Lavender.Services.ProductionEmps.Queries.GetById;
using Lavender.Services.Users.Commands.Add;
using Lavender.Services.Users.Commands.Delete;
using Lavender.Services.Users.Commands.ForgetPassword;
using Lavender.Services.Users.Commands.Login;
using Lavender.Services.Users.Commands.RefreshToken;
using Lavender.Services.Users.Commands.Update;
using Lavender.Services.Users.Queries.GetAllMainUsers;
using Lavender.Services.Users.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using static Lavender.Services.PatternMakers.Queries.GetAll.GetAllPatternMakerRequest;
using static Lavender.Services.ProductionEmps.Queries.GetAll.GetAllProductionEmpRequest;
using static Lavender.Services.Users.Queries.GetAllMainUsers.GetAllUsersRequest;
using static Lavender.Services.Users.Queries.GetById.GetUserByIdRequest;

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
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddUser([FromForm] AddUserRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }


        [HttpPut("UpdateUser")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromForm] UpdateUserRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }


        [HttpDelete("DeleteUser")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody] DeleteUserRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        [HttpPut("UpdatePatternMaker")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromForm] UpdatePatternMakerRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpPut("UpdateProductionEmp")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromForm] UpdateProductionEmpRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
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

        [HttpGet("GetProductionEmpById")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<ProductionEmpResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] GetProductionEmpByIdRequest request, CancellationToken cancellationToken)
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
