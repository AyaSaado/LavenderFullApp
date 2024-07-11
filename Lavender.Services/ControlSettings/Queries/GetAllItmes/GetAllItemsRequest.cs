using Lavender.Core.Entities;
using MediatR;
using System.Linq.Expressions;

namespace Lavender.Services.ControlSettings
{
    public class GetAllItemsRequest : IRequest<List<ItemResponse>>
    {
        public string? ItemName { get; set; } 
    }  
    public class ItemResponse
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
           
            public static Expression<Func<Item, ItemResponse>> Selector() => c
                => new()
                {
                    Id = c.Id,
                    Name = c.Name,
       
                };
        }
}
