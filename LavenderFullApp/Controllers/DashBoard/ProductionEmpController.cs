using Lavender.Core.EntityDto;
using Lavender.Core.Shared;
using Lavender.Services.ProductionEmps.Commands.Add;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LavenderFullApp.Controllers.DashBoard
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "DashBoard")]
    public class ProductionEmpController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductionEmpController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Add")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result<ProductionEmpDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(AddProductionEmpRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

 
    }
}
