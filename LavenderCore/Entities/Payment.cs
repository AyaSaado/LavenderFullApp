
using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public decimal PaidMoney { get; set; }
        public DateOnly PayingDate { get; set; }
        public Order Order { get; set; } = null!;
    }
}
