using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class Plan
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public int ItemSizeId { get; set; }
        public int StepId { get; set; }
        public ItemSize ItemSize { get; set; } = null!;   
        public Step Step { get; set; } = null!;
        
    }
}
