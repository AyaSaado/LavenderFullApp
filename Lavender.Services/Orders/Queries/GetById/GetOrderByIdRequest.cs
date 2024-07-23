using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Enum;
using Lavender.Core.Shared;
using MediatR;
using System.Linq.Expressions;
using static Lavender.Core.Helper.MappingProfile;
namespace Lavender.Services.Orders
{
    public class GetOrderByIdRequest : IRequest<Result<OrderResponse>>
    {
        public int OrderId { get; set; }
    } 
    public class OrderResponse
        {
            public int Id { get; set; }
            public DateOnly OrderDate { get; set; }
            public DateOnly DeliveryDate { get; set; }
            public Ordertype OrderType { get; set; }
            public Guid ActorId { get; set; }
            public Guid? ProductionLineId { get; set; }
            public OrderState OrderState { get; set; }
            public int ItemId { get; set; }
            public int ItemTypeId { get; set; }
            public DateOnly StartDate { get; set; }
            public DateOnly EndDate { get; set; }
            public int GalleryDesignId { get; set; }
            public decimal DesignPrice { get; set; }
            public decimal TotalPrice { get; set; }
            public int ItemsCount { get; set; }
            public List<string> UsedFabrics { get; set; } = new List<string>();
            public ICollection<ItemSizeDto> ItemSizeDtos { get; set; } = new List<ItemSizeDto>();
            public static Expression<Func<Order, OrderResponse>> Selector() => o
             => new()
             {
                 Id = o.Id,
                 ActorId = o.ActorId,
                 ProductionLineId = o.ProductionLineId,
                 DeliveryDate = o.DeliveryDate,
                 OrderDate = o.OrderDate,
                 OrderType = o.OrderType,
                 OrderState = o.OrderState,
                 ItemId = o.ItemId,
                 ItemTypeId = o.ItemTypeId,
                 StartDate = o.StartDate,
                 EndDate = o.EndDate,
                 GalleryDesignId = o.GalleryDesignId,
                 ItemSizeDtos = Mapping.Mapper.Map<List<ItemSizeDto>>(o.ItemSizes)
             };

        }
}
