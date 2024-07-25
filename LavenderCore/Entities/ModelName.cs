using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class ModelName
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Productivity { get; set; }
        public ICollection<SewingMachine> SewingMachines { get; set; } = new List<SewingMachine>();    
    }
}
