
namespace Lavender.Core.EntityDto
{
    public class ProductionEmpDto 
    {
        public Guid Id { get; set; }
        public string? ImageProfileUrl { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = string.Empty;
        public Guid? HeadId { get; set; }
        public int LineTypeId { get; set; }
        public decimal Salary { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NationalNumber { get; set; }
        public DateOnly BirthDay { get; set; }
        public string? Role { get; set; }
    }
}
