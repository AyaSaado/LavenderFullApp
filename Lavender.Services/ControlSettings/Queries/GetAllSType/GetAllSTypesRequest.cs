using Lavender.Core.Entities;
using MediatR;
using System.Linq.Expressions;

namespace Lavender.Services.ControlSettings
{
    public class GetAllSTypesRequest : IRequest<List<STypeResponse>>
    {

      
    } 
      public class STypeResponse
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;

            public static Expression<Func<SType, STypeResponse>> Selector() => c
                => new()
                {
                    Id = c.Id,
                    Name = c.Name,

                };
        }
}
