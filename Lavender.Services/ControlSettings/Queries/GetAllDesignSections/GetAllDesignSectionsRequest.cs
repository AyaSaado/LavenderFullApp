using Lavender.Core.Entities;
using MediatR;
using System.Linq.Expressions;

namespace Lavender.Services.ControlSettings
{
    public class GetAllDesignSectionsRequest : IRequest<List<DesignSectionResponse>>
    {
      
      
    }
    public class DesignSectionResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public static Expression<Func<DesigningSection, DesignSectionResponse>> Selector() => c
            => new()
            {
                Id = c.Id,
                Name = c.Name,
            };
    }
}

