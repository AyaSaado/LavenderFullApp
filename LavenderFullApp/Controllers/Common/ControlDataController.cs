using Lavender.Services.ControlSettings.Queries.GetAllDesignSections;
using Lavender.Services.ControlSettings.Queries.GetAllLineTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static Lavender.Services.ControlSettings.Queries.GetAllDesignSections.GetAllDesignSectionsRequest;
using static Lavender.Services.ControlSettings.Queries.GetAllLineTypes.GetAllLineTypesRequest;

namespace LavenderFullApp.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Common")]
    [ApiController]
    public class ControlDataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ControlDataController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAllDesignSections")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(DesignSectionResponse))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDesignSectionsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }


        [HttpGet("GetAllLineTypes")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(LineTypeResponse))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllLineTypesRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }


    }
}
