

using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public decimal Amount { get; set; }
        public decimal CostOfUnit { get; set; }
        public SItemType SItemType { get; set; } = null!;
        public Factory Factory { get; set; } = null!;
     }
}
