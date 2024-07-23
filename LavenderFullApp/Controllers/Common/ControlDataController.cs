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
    
    public class ControlDataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ControlDataController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAllDesignSections")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(DesignSectionResponse))]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDesignSectionsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }


        [HttpGet("GetAllLineTypes")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(LineTypeResponse))]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] GetAllLineTypesRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetAllItems")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<ItemResponse>))]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] GetAllItemsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetItemById")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(ItemResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] GetItemByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result is not null ? Ok(result) : NotFound();
        }


        [HttpGet("GetAllItemTypes")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(ItemTypesResponse))]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] GetAllItemTypesRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetItemTypeById")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(ItemTypesResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] GetItemTypeByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpGet("GetAllItemTypesOfStoreRequest")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<STypeResponse>))]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSTypesRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }


        [HttpGet("GetAllStoreItems")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<ControlData>))]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] GetAllStoreItemsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }


        [HttpGet("GetItemDetails")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<ItemDetailResponse>))]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] GetItemDetailsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetItemDetailsById")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(ItemDetailResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] GetItemDetailsByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return result is not null ? Ok(result) : NotFound();
        }
    }
}
