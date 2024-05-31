
using MediatR;

namespace Lavender.Services.ControlSettings.Commands.Delete.DeleteItemTypes
{
    public class DeleteItemTypesRequest : IRequest<bool>
    {
        public List<int> Ids { get; set; } = new List<int>();
    }
}
