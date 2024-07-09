
using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class SItemType
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; } = null!;
        public decimal Amount {  get; set; }
        public decimal MinAmount { get; set; }
        public int STypeId { get; set; }
        public int StoreItemId { get; set; }
        public SType SType { get; set; } = null!;
        public StoreItem StoreItem { get; set; } = null!;
        public ICollection<Consuming> Consumings { get; set; } = new List<Consuming>();

    }
}
