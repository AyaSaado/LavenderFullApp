

using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class LineType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ProductionEmp> ProductionEmps { get; set; } = new List<ProductionEmp>();
    }
}
