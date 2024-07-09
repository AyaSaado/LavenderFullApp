using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LavenderFullApp.Controllers.DashBoard
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "DashBoard")]
    [Authorize]
    public class ProductionEmpController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductionEmpController(IMediator mediator)
        {
            _mediator = mediator;
        }

 
    }
}
