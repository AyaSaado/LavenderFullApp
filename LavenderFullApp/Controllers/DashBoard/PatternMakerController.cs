using Lavender.Core.Shared;
using Lavender.Services.PatternMakers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LavenderFullApp.Controllers.DashBoard
{

    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "DashBoard")]
    public class PatternMakerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatternMakerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddPatternMaker")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromForm] AddPatternMakerRequest command , CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

    
    }
}
