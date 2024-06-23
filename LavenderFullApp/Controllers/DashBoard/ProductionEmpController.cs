using Lavender.Core.Shared;
using Lavender.Services.ProductionEmps;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("AddProductionEmp")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromForm] AddProductionEmpRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
          
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

 
    }
}
