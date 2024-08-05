using Lavender.Services.Chats;
using Lavender.Services.Chats.Queries.GetMessagesOfChat;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LavenderFullApp.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Common")]
    [Authorize]
    public class ChatsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChatsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllChatsOfUser")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<ChatResponse>))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllChatsRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetMessagesOfChat")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<MessageResponse>))]
        public async Task<IActionResult> GetAll([FromQuery] GetMessagesOfChatRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPost("AddChat")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] AddChatRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : BadRequest();
        }

        [HttpPost("AddMessageToChat")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromForm] AddMessageToChatRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result ? Ok() : BadRequest();
        }
    }
}
