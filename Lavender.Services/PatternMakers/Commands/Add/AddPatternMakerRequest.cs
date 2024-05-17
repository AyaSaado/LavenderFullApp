using MediatR;
using Lavender.Core.Shared;
using Lavender.Core.EntityDto;
using Microsoft.AspNetCore.Http;

namespace Lavender.Services.PatternMakers.Commands.Add
{
    public class AddPatternMakerRequest : IRequest<Result<PatternMakerDto>>
    {
        public Guid Id { get; set; }
        public IFormFile? ImageProfile { get; set; } 
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public decimal Salary {  get; set; } 
        public string PhoneNumber { get; set; } = null!;
        public string? NationalNumber { get; set; }
        public DateOnly BirthDay { get; set; }
        public string Role { get; set; } = null!; 
        public List<int> DesignSectionIds { get; set; } = new List<int>();  

    }



}
