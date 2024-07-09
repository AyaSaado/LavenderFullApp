using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LavenderFullApp.Controllers.DashBoard
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "DashBoard")]
    [Authorize]
    public class DesignController : ControllerBase
    {
    }
}
