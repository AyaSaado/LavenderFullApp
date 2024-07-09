using Lavender.Services.Designs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LavenderFullApp.Controllers.DashBoard
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "DashBoard")]
    [Authorize]
    public class DesignController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DesignController(IMediator mediator)
        {
            _mediator = mediator;
        }



    }
}
