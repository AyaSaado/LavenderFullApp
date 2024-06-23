using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using MediatR;
using System.Linq.Expressions;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.ProductionEmps
{
    public class GetAllProductionEmpRequest : IRequest<List<ProductionEmpResponse>>
    {

      
    }  
    public class ProductionEmpResponse
        {
            public Guid Id { get; set; }
            public string? ProfileImageUrl { get; set; }
            public string FullName { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string UserName { get; set; } = null!;
            public ProductionHeadDto? ProductionHeadDto { get; set; }
            public LineTypeDto LineTypeDto { get; set; } = null!;
            public decimal Salary { get; set; }
            public string? PhoneNumber { get; set; } = null!;
            public string? NationalNumber { get; set; }
            public string? Address { get; set; }
            public DateOnly BirthDay { get; set; }

            public static Expression<Func<ProductionEmp, ProductionEmpResponse>> Selector() => p
               => new()
               {
                   Id = p.Id,
                   FullName = p.FullName,
                   Email = p.Email!,
                   UserName = p.UserName!,
                   BirthDay = p.BirthDay,
                   NationalNumber = p.NationalNumber,
                   PhoneNumber = p.PhoneNumber,
                   Address = p.Address,
                   ProfileImageUrl = p.ProfileImageUrl,
                   Salary = p.Salary,
                   LineTypeDto = Mapping.Mapper.Map<LineTypeDto>(p.LineType),
                   ProductionHeadDto = Mapping.Mapper.Map<ProductionHeadDto>(p.Head)

               };

        }
}
