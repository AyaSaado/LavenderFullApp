using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class Accessory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<DesignAccessory> DesignAccessories { get; set; } = new List<DesignAccessory>();
    }
}
