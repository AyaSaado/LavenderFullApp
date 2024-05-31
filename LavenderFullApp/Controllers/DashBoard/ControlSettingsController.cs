using Lavender.Services.ControlSettings.Commands.Add.AddDesignSections;
using Lavender.Services.ControlSettings.Commands.Add.AddItems;
using Lavender.Services.ControlSettings.Commands.Add.AddLineTypes;
using Lavender.Services.ControlSettings.Commands.Add.AddtemTypes;
using Lavender.Services.ControlSettings.Commands.Delete.DeleteDesignSections;
using Lavender.Services.ControlSettings.Commands.Delete.DeleteItems;
using Lavender.Services.ControlSettings.Commands.Delete.DeleteItemTypes;
using Lavender.Services.ControlSettings.Commands.Delete.DeleteLineTypes;
using Lavender.Services.ControlSettings.Commands.Update.UpdateDesignSections;
using Lavender.Services.ControlSettings.Commands.Update.UpdateLineTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LavenderFullApp.Controllers.DashBoard
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "DashBoard")]
    public class ControlSettingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ControlSettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("AddDesignSections")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] AddDesignSectionsRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command , cancellationToken);
            return result ? Ok() : BadRequest();
        }


        [HttpPut("UpdateDesignSection")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateDesignSectionRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("DeleteDesignSections")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody] DeleteDesignSectionsRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? NoContent() : BadRequest();
        }


        [HttpPost("AddLineTypes")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] AddLineTypesRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : BadRequest();
        }


        [HttpPut("UpdateLineType")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateLineTypeRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : NotFound();
        }


        [HttpDelete("DeleteLineTypes")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody] DeleteLineTypesRequest command , CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? NoContent() : BadRequest();
        }

        [HttpPost("AddItems")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] AddItemsRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : BadRequest();
        }


        [HttpDelete("DeleteItems")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody] DeleteItemsRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? NoContent() : BadRequest();
        }


        [HttpPost("AddItemTypes")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] AddItemTypesRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : BadRequest();
        }


        [HttpDelete("DeleteItemTypes")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody] DeleteItemTypesRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? NoContent() : BadRequest();
        }

    }
}
