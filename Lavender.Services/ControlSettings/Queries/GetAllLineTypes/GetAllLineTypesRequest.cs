using Lavender.Core.Entities;
using MediatR;
using System.Linq.Expressions;
using static Lavender.Services.ControlSettings.Queries.GetAllLineTypes.GetAllLineTypesRequest;

namespace Lavender.Services.ControlSettings.Queries.GetAllLineTypes
{
    public class GetAllLineTypesRequest : IRequest<List<LineTypeResponse>>
    {
      
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
}
