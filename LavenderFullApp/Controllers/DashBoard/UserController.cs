using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LavenderFullApp.Controllers.DashBoard
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "DashBoard")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

       
    }
}
