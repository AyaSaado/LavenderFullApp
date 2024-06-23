using Lavender.Core.EntityDto;
using Lavender.Services.ControlSettings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

        [HttpGet("GetAllItems")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(ItemsResponse))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllItemsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetAllItemTypes")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(ItemTypesResponse))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllItemTypesRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }


        [HttpGet("GetAllFabrics")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(FabricTypeResponse))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllFabricsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }


        [HttpGet("GetAllAccessories")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(ControlData))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAccessoriesRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

    }
}
