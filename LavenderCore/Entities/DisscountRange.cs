

using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class DisscountRange
    {
        [Key]
        public int Id { get; set; }
        public int FromQuantity { get; set; }
        public int ToQuantity { get; set; }
        public decimal Disscount { get; set; }
    }
}
