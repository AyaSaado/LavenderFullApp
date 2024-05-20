using MediatR;

namespace Lavender.Services.ControlSettings.Commands.Update.UpdateLineTypes
{
    public class UpdateLineTypeRequest : IRequest<bool> 
    {
        public int Id { get; set; }
        public string LineTypeName { get; set; } = null!;
    }
}
