using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using MediatR;
using static Lavender.Services.ControlSettings.Queries.GetAllLineTypes.GetAllLineTypesRequest;
using System.Linq.Expressions;
using static Lavender.Core.Helper.MappingProfile;
using static Lavender.Services.PatternMakers.Queries.GetAll.GetAllPatternMakerRequest;

namespace Lavender.Services.PatternMakers.Queries.GetAll
{
    public class GetAllPatternMakerRequest : IRequest<List<PatternMakerResponse>>
    {

        public class PatternMakerResponse
        {
            public Guid Id { get; set; }
            public string? ProfileImageUrl { get; set; }
            public string FullName { get; set; } = null!;
            public string Email { get; set; } = null!;
            public  string UserName { get; set; } = null!;
            public string? PhoneNumber { get; set; }
            public string? NationalNumber { get; set; }
            public string? Address { get; set; }
            public DateOnly BirthDay { get; set;} 
            public decimal Salary { get; set; }
            public List<DesignSectionDto> DesignSectionDtos { get; set; } = new List<DesignSectionDto>();

            public static Expression<Func<PatternMaker, PatternMakerResponse>> Selector() => p
               => new()
               {
                   Id = p.Id,
                   FullName = p.FullName,
                   Email = p.Email!,
                   UserName = p.UserName!,
                   BirthDay = p.BirthDay,
                   ProfileImageUrl = p.ProfileImageUrl,     
                   PhoneNumber = p.PhoneNumber,
                   Address = p.Address,
                   NationalNumber = p.NationalNumber,
                   Salary = p.Salary,
                   DesignSectionDtos = Mapping.Mapper.Map<List<DesignSectionDto>>(p.MakerSections
                                      .Select(m => m.DesigningSection).ToList())


               };

        }
    }

}
