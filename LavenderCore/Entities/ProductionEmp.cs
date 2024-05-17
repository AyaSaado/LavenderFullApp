

namespace Lavender.Core.Entities
{
    public class ProductionEmp : User
    {
      
        public decimal Salary { get; set; } 
        public ProductionEmp? Head { get; set; }
        public LineType LineType { get; set; } = null!;
        public string? ImageProfileUrl { get; set; }
        public ICollection<ProductionEmp> MyEmployees { get; set; } = new List<ProductionEmp>();
    

        public void Update(string fullName, string phoneNumber, 
                          string? nationalNumber, DateOnly birthDay,
                          decimal salary,
                          ProductionEmp? head , LineType lineType)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            NationalNumber = nationalNumber;
            BirthDay = birthDay;
            Salary = salary;
            Head = head;
            LineType = lineType;    
        }
    }
}
