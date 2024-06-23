using Lavender.Core.Entities;
using MediatR;
using System.Linq.Expressions;

namespace Lavender.Services.ControlSettings
{
    public class GetAllFabricsRequest : IRequest<List<FabricTypeResponse>>
    {

      
    } 
      public class FabricTypeResponse
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;

            public static Expression<Func<FabricType, FabricTypeResponse>> Selector() => c
                => new()
                {
                    Id = c.Id,
                    Name = c.Name,

                };
        }
}
