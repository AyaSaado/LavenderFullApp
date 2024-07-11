using Lavender.Core.EntityDto;
using Lavender.Services.ControlSettings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LavenderFullApp.Controllers.Common
{
    [Route("api/[controller]")] 
    [ApiExplorerSettings(GroupName = "Common")]
    [ApiController]
    [Authorize]
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
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<ItemResponse>))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllItemsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetItemById")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(ItemResponse))]
        public async Task<IActionResult> Get([FromQuery] GetItemByIdRequest request, CancellationToken cancellationToken)
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


        [HttpGet("GetAllItemTypesOfStoreRequest")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<STypeResponse>))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSTypesRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }


        [HttpGet("GetAllStoreItems")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<ControlData>))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllStoreItemsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }


        [HttpGet("GetItemDetails")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<ItemDetailResponse>))]
        public async Task<IActionResult> GetAll([FromQuery] GetItemDetailsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }
    }
}
