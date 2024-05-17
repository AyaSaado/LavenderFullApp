
using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class ItemType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public  ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
