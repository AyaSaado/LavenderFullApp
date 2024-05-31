

using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class Plan
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public int ItemSizeWithColorId { get; set; }
        public int StepId { get; set; }
        public ItemSizeWithColor ItemSizeWithColor { get; set; } = null!;   
        public Step Step { get; set; } = null!;
        
    }
}
