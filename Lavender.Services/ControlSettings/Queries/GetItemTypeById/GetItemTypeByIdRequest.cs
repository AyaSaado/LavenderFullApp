using MediatR;


namespace Lavender.Services.ControlSettings
{
    public class GetItemTypeByIdRequest : IRequest<ItemTypesResponse?>
    {
        public int ItemTypeId { get; set; }
    }
   
}
