using Lavender.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class DesignAccessory
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public TypeOfUnit TypeOfUnit { get; set; }
        public string Color { get; set; } = null!;
        public int DesignId { get; set; }
        public int AccessoryId { get; set; }
        public Design Design { get; set; } = null!;
        public Accessory Accessory { get; set; } = null!;
    }
}
