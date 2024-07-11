using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class AddStoreItemsRequest  : IRequest<bool>
    {
        public List<ControlData> StoreItemDtos{ get; set; } = new List<ControlData>();

    }

}
