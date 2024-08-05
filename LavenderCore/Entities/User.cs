using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lavender.Core.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; } = null!;
        public string? ProfileImageUrl { get; set; }
        public decimal Salary { get; set; }

        [Column(TypeName = "varchar(50)")]
        public override string? PhoneNumber { get; set; }
        public string? NationalNumber { get; set; }
        public DateOnly BirthDay { get; set; }
        public string? Address { get; set; }

        public void Update(string fullName, string? phoneNumber,decimal salary,
                        string? nationalNumber, DateOnly birthDay,
                        string? address)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            NationalNumber = nationalNumber;
            BirthDay = birthDay;
            Address = address;
            Salary = salary;
        }
    }
}
