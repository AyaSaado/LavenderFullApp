

using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class LineType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Worker_Wage_EachHour { get; set; }
        public decimal ProductionManager_Salary { get; set; }
        public ICollection<ProductionEmp> ProductionEmps { get; set; } = new List<ProductionEmp>();
    }
}
