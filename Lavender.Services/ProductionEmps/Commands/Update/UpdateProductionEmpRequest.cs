using Lavender.Core.EntityDto;
using Lavender.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Lavender.Services.ProductionEmps.Commands.Update
{
    public class UpdateProductionEmpRequest : IRequest<Result<ProductionEmpDto>>
    {
        public Guid Id { get; set; }
        public IFormFile? ImageProfile { get; set; }
        public string FullName { get; set; } = null!;
        public string? Password { get; set; }
        public Guid? HeadId { get; set; }
        public int LineTypeId { get; set; } = -1;
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? NationalNumber { get; set; }
        public DateOnly BirthDay { get; set; }
    }
}
