
using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class SItemType
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; } = null!;
        public decimal Amount {  get; set; }
        public SType SType { get; set; } = null!;
        public StoreItem StoreItem { get; set; } = null!;
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
