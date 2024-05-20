using Lavender.Services.ControlSettings.Commands.Add.AddDesignSections;
using Lavender.Services.ControlSettings.Commands.Add.AddLineTypes;
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

    }
}
