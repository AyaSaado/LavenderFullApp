
namespace Lavender.Core.Entities
{
    public class PatternMaker : User
    {
        public decimal Salary { get; set; }
        public ICollection<InspirationImage> InspirationImages { get; set; } = new List<InspirationImage>();
        public ICollection<MakerSection> MakerSections { get; set; } = new List<MakerSection>();

        public void Update(string fullName , string phoneNumber,
                           string? nationalNumber, DateOnly birthDay
                          ,decimal salary, string? address)
        {
           FullName = fullName;
           PhoneNumber = phoneNumber;
           NationalNumber = nationalNumber;
           BirthDay = birthDay;
           Salary = salary;
           Address = address;
        }

    }
}