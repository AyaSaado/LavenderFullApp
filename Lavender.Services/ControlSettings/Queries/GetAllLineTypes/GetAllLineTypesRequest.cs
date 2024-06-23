using Lavender.Core.Entities;
using MediatR;
using System.Linq.Expressions;

namespace Lavender.Services.ControlSettings
{
    public class GetAllLineTypesRequest : IRequest<List<LineTypeResponse>>
    {
      
      
    }  
    public class LineTypeResponse
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
           
            public static Expression<Func<LineType, LineTypeResponse>> Selector() => c
                => new()
                {
                    Id = c.Id,
                    Name = c.Name,
       
                };
        }
}
