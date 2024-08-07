﻿using Lavender.Core.Shared;
using Lavender.Services.PatternMakers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Swashbuckle.AspNetCore.Annotations;

namespace LavenderFullApp.Controllers.DashBoard
{

    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "DashBoard")]
    [Authorize]
    public class PatternMakerController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IStringLocalizer<PatternMakerController> _localization;
        public PatternMakerController(IMediator mediator, IStringLocalizer<PatternMakerController> localization)
        {
            _mediator = mediator;
            _localization = localization;
        }

        [HttpPost("AddPatternMaker")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(Result))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromForm] AddPatternMakerRequest command , CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Ok() : BadRequest(_localization[result.Error.Message]);
        }

    
    }
}
