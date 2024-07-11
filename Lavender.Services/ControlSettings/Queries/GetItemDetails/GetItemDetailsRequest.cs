using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using MediatR;
using System.Linq.Expressions;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.ControlSettings
{
    public class GetItemDetailsRequest : IRequest<List<ItemDetailResponse>>
    {
    }

    public class ItemDetailResponse
    {
        public int Id { get; set; }
        public string Color { get; set; } = null!;
        public decimal Amount { get; set; }
        public decimal MinAmount { get; set; }
        public ControlData StoreItem { get; set; } = null!;
        public ControlData SType { get; set; } = null!;
        public static Expression<Func<SItemType, ItemDetailResponse>> Selector() => c
            => new()
            {
                Id = c.Id,
                Amount = c.Amount,
                Color = c.Color,
                MinAmount = c.MinAmount,
                StoreItem = Mapping.Mapper.Map<ControlData>(c.StoreItem),       
                SType = Mapping.Mapper.Map<ControlData>(c.SType)
            };
            
            
     } 
            
}
