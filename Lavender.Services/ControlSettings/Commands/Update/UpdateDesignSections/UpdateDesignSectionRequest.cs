﻿using Lavender.Core.EntityDto;
using Lavender.Core.Shared;
using MediatR;

namespace Lavender.Services.ControlSettings.Commands.Update.UpdateDesignSections
{
    public class UpdateDesignSectionRequest : IRequest<bool>
    {
        public required int Id { get; set; }
        public required string DesignSectionName { get; set; }
    }
}
