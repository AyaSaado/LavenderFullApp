﻿using Lavender.Core.Entities;
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
            public OrderState OrderState { get; set; }
            public int ItemId { get; set; }
            public int ItemTypeId { get; set; }
            public ICollection<ItemSizeDto> ItemSizeDtos { get; set; } = new List<ItemSizeDto>();
            public static Expression<Func<Order, OrderResponse>> Selector() => o
             => new()
             {
                 Id = o.Id,
                 ActorId = o.ActorId,
                 DeliveryDate = o.DeliveryDate,
                 OrderDate = o.OrderDate,
                 OrderType = o.OrderType,
                 OrderState = o.OrderState,
                 ItemId = o.ItemId,
                 ItemTypeId = o.ItemTypeId,
                 ItemSizeDtos = Mapping.Mapper.Map<List<ItemSizeDto>>(o.ItemSizes)
             };

        }
}
