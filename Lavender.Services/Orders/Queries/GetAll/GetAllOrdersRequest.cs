using Lavender.Core.Entities;
using Lavender.Core.Enum;
using MediatR;
using System.Linq.Expressions;

namespace Lavender.Services.Orders
{
    public class GetAllOrdersRequest : IRequest<List<OrdersResponse>>
    {
        public Guid ActorId { get; set; }
        public OrderState OrderState { get; set; }

      
    }  
    public class OrdersResponse
        {
            public int Id { get; set; }
            public DateOnly OrderDate { get; set; }
            public DateOnly DeliveryDate { get; set; }
            public Ordertype OrderType { get; set; }
            public Guid ActorId { get; set; }
            public int ItemId { get; set; }
            public int ItemTypeId { get; set; }
            public string? FeedBack { get; set; }
            public DateOnly StartDate { get; set; }
            public DateOnly EndDate { get; set; }
            public int GalleryDesignId { get; set; }
        public static Expression<Func<Order, OrdersResponse>> Selector() => o
             => new()
             {
                 Id = o.Id,
                 ActorId = o.ActorId,
                 DeliveryDate = o.DeliveryDate,
                 OrderDate = o.OrderDate,
                 OrderType = o.OrderType,
                 ItemId = o.ItemId,
                 ItemTypeId = o.ItemTypeId,
                 FeedBack = o.Feedback,
                 StartDate = o.StartDate,
                 EndDate = o.EndDate,
                 GalleryDesignId = o.GalleryDesignId,
             };

        }

}
