
using MediatR;

namespace Lavender.Services.ControlSettings.Commands.Delete.DeleteItems
{
    public class DeleteItemsRequest : IRequest<bool>
    {
        public List<int> Ids { get; set; } = new List<int>();
    }
}
