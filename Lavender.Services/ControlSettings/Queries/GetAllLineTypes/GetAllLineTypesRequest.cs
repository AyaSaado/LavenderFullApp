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
            public decimal Worker_Wage_EachHour { get; set; }
            public decimal ProductionManager_Salary { get; set; }
            public static Expression<Func<LineType, LineTypeResponse>> Selector() => c
                => new()
                {
                    Id = c.Id,
                    Name = c.Name,
                    ProductionManager_Salary = c.ProductionManager_Salary,
                    Worker_Wage_EachHour = c.Worker_Wage_EachHour
       
                };
        }
}
