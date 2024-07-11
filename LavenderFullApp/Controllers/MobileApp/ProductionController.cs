using Lavender.Core.EntityDto;
using Lavender.Services.Plans;
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
    public class ProductionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetProductionSteps")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<ControlData>))]
        public async Task<IActionResult> GetAll([FromQuery] GetProductionStepsRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetProductionStepById")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(ControlData))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] GetProductionStepByIdRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpGet("GetPlansOfOrder")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<PlanOfOrderResponse>))]
        public async Task<IActionResult> GetAll([FromQuery] GetPlansOfOrderRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }


        [HttpPost("UpsertPlansOfOrder")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Upsert([FromBody] UpsertPlansOfOrderRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result  ? Ok() : BadRequest();
        }

        [HttpDelete("DeletePlanOfOrder")]
        [SwaggerResponse(StatusCodes.Status204NoContent, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody] DeletePlansOfOrderRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? NoContent() : BadRequest();
        }
    }
}
