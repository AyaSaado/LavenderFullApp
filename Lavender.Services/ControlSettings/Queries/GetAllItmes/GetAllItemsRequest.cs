using Lavender.Core.Entities;
using MediatR;
using System.Linq.Expressions;
using static Lavender.Services.ControlSettings.Queries.GetAllItems.GetAllItemsRequest;

namespace Lavender.Services.ControlSettings.Queries.GetAllItems
{
    public class GetAllItemsRequest : IRequest<List<ItemsResponse>>
    {
      
        public class ItemsResponse
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
           
            public static Expression<Func<Item, ItemsResponse>> Selector() => c
                => new()
                {
                    Id = c.Id,
                    Name = c.Name,
       
                };
        }
    }
}
