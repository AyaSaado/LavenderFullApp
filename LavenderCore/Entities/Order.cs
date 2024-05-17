
using Lavender.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateOnly OrderDate { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public string? Feedback { get; set; }
        public Ordertype OrderType{ get; set; }
        public Actor Actor { get; set; } = null!;
        public Item Item { get; set; } = null!;
        public ItemType ItemType { get; set; } = null!;   
        public  ICollection<ItemSize> ItemSizes { get; set; } = new List<ItemSize>();
        public  ICollection<Payment> Payments { get; set; } = new List<Payment>();
       

    }
}
