using Lavender.Core.EntityDto;
using Lavender.Core.Shared;
using Lavender.Services.DesignSections.Commands.Add;
using Lavender.Services.DesignSections.Commands.Update;
using Lavender.Services.DesignSections.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LavenderFullApp.Controllers.DashBoard
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "DashBoard")]
    public class DesignSectionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DesignSectionController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("Add")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<DesignSectionDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(AddDesignSectionsRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }


        [HttpPut("Update")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<DesignSectionDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateDesignSectionRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }


        [HttpGet("GetAll")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<DesignSectionDto>))]
        public async Task<IActionResult> GetAll(GetAllDesignSectionsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request);
            return Ok(result) ;
        }

    }
}
