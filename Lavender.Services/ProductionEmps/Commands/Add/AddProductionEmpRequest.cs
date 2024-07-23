using Lavender.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Lavender.Services.ProductionEmps
{
    public class AddProductionEmpRequest : IRequest<Result>
    {
        public Guid Id { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? UserName { get; set; } 
        public string? Password { get; set; } 
        public Guid? HeadId { get; set; }
        public int LineTypeId { get; set; }
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? NationalNumber { get; set; }
        public string? Address { get; set; }
        public DateOnly BirthDay { get; set; }
        public string Role { get; set; } = null!;
    }
}
