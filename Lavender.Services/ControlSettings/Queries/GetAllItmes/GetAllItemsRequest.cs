using Lavender.Core.Entities;
using MediatR;
using System.Linq.Expressions;

namespace Lavender.Services.ControlSettings
{
    public class GetAllItemsRequest : IRequest<List<ItemDto>>
    {
        public string? ItemName { get; set; } 
    }  
    public class ItemDto
    {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public decimal Discount { get; set; }
            public static Expression<Func<Item, ItemDto>> Selector() => c
                => new()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Discount = c.Discount
                };
    }
}
