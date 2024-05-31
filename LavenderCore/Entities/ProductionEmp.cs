namespace Lavender.Core.Entities
{
    public class ProductionEmp : User
    {
      
        public decimal Salary { get; set; }
        public int LineTypeId { get; set; }
        public Guid? HeadId { get; set; }
        public ProductionEmp? Head { get; set; }
        public LineType LineType { get; set; } = null!;
        public ICollection<ProductionEmp> MyEmployees { get; set; } = new List<ProductionEmp>();
    

        public void Update(string fullName, string phoneNumber, 
                          string? nationalNumber, DateOnly birthDay,
                          decimal salary,string? address)
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
