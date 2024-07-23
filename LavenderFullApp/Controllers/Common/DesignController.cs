using Lavender.Core.Shared;
using Lavender.Services.Designs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace LavenderFullApp.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Common")]
 
    public class DesignController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DesignController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetGalleryDesigns")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<AllDesignsResponse>))]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDesignsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetOneGalleryDesign")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(OneDesignResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] GetDesignByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result is not null ? Ok(result) : NotFound();
        }


        [HttpGet("GetDesignImageUrlRequest")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(string))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] GetDesignImageUrlRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return !result.IsNullOrEmpty() ? Ok(result) : NotFound();
        }


        [HttpPut("UpdateDesign")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Update([FromForm] UpdateDesignRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpDelete("DeleteDesign")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Delete([FromBody] DeleteDesignRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? NoContent() : BadRequest();
        }

       
    }
}
