using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LavenderFullApp.Controllers.MobileApp
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "MobileApp")]
    public class CustmomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustmomerController(IMediator mediator)
        {
            _mediator = mediator;
        }


    }
}
