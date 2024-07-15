using MediatR;


namespace Lavender.Services.ControlSettings
{
    public class GetItemDetailsByIdRequest : IRequest<ItemDetailResponse?>
    {
        public int SItemTypeId { get; set; }
    }

            
}
