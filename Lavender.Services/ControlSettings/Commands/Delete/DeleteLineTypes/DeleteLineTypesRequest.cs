﻿
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class DeleteLineTypesRequest : IRequest<bool>
    {
        public List<int> Ids { get; set; } = new List<int>();
    }
}
