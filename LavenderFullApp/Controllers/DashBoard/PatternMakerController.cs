using Lavender.Core.EntityDto;
using Lavender.Core.Shared;
using Lavender.Services.PatternMakers.Commands.Add;
using MediatR;
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

        [HttpPost("Add")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<PatternMakerDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(AddPatternMakerRequest command , CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }


    }
}
