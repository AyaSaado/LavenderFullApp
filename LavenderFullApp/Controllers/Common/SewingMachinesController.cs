using Lavender.Core.EntityDto;
using Lavender.Services.ControlSettings;
using Lavender.Services.Orders;
using Lavender.Services.SewingMachines;
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
    public class SewingMachinesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SewingMachinesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllSewingMachines")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<SewingMachineResponse>))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSewingMachinesRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetSewingMachineById")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(SewingMachineResponse))]
        public async Task<IActionResult> Get([FromQuery] GetSewingMachineByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetModelName (All / ById)")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<ModelNameDto>))]
        public async Task<IActionResult> GetAll([FromQuery] GetModelNameRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetDailyProductivityOfEmp")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<DailyProductivityDto>))]
        public async Task<IActionResult> GetAll([FromQuery] GetDailyProductivityOfEmpRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPost("AddSewingMachine")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] AddSewingMachineRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        [HttpPut("UpdateSewingMachine")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateSewingMachineRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("DeleteSewingMachines")]
        [SwaggerResponse(StatusCodes.Status204NoContent, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromBody] DeleteSewingMachinesRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? NoContent() : NotFound();
        }

        [HttpPost("UpsertModelNames")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Upsert([FromBody] UpsertModelNamesRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("DeleteModelNames")]
        [SwaggerResponse(StatusCodes.Status204NoContent, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromBody] DeleteModelNamesRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? NoContent() : NotFound();
        }

        [HttpPost("UpsertDailyProductivity")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Upsert([FromBody] UpsertDailyProductivityRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("DeleteDailyProductivity")]
        [SwaggerResponse(StatusCodes.Status204NoContent, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromBody] DeleteDailyProductivityRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? NoContent() : NotFound();
        }
    }
}
