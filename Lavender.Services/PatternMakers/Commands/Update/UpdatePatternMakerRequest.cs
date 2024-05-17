

using MediatR;
using Lavender.Core.Shared;
using Lavender.Core.EntityDto;
using Microsoft.AspNetCore.Http;

namespace Lavender.Services.PatternMakers.Commands.Update
{
    public class UpdatePatternMakerRequest : IRequest<Result<PatternMakerDto>>
    {
        public Guid Id { get; set; }
        public IFormFile? ImageProfile { get; set; }
        public required string FullName { get; set; }
        public string? Password { get; set; }
        public decimal Salary { get; set; }
        public required string PhoneNumber { get; set; }
        public string? NationalNumber { get; set; }
        public required DateOnly BirthDay { get; set; }
    }

        

}
