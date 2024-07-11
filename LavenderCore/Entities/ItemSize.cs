

using Lavender.Core.Enum;
using System.ComponentModel.DataAnnotations;


namespace Lavender.Core.Entities
{
    public class ItemSize
    {
        [Key]
        public int Id { get; set; }
        public Size Size { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public ICollection<ItemSizeWithColor> ItemSizeWithColors { get; set; } = new List<ItemSizeWithColor>();
        public ICollection<Plan> Plans { get; set; } = new List<Plan>();
    }
}
