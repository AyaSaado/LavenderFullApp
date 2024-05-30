
using MediatR;

namespace Lavender.Services.ControlSettings.Commands.Delete.DeleteDesignSections
{
    public class DeleteDesignSectionsRequest : IRequest<bool>
    {
        public List<int> Ids { get; set; } = new List<int>(); 
    }
}
