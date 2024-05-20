using Lavender.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Lavender.Services.ProductionEmps.Commands.Update
{
    public class UpdateProductionEmpRequest : IRequest<Result>
    {
        public Guid Id { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public string FullName { get; set; } = null!;
        public string? Password { get; set; }
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }
        public string? NationalNumber { get; set; }
        public DateOnly BirthDay { get; set; }
    }
}
