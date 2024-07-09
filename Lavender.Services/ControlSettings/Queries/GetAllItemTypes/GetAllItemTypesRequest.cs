using Lavender.Core.Entities;
using MediatR;
using System.Linq.Expressions;
using static Lavender.Services.ControlSettings.GetAllItemTypesRequest;

namespace Lavender.Services.ControlSettings
{
    public class GetAllItemTypesRequest : IRequest<List<ItemTypesResponse>>
    {
        public string? ItemTypeName { get; set; }

    }  
       public class ItemTypesResponse
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
           
            public static Expression<Func<ItemType, ItemTypesResponse>> Selector() => c
                => new()
                {
                    Id = c.Id,
                    Name = c.Name,
       
                };
        }
}
