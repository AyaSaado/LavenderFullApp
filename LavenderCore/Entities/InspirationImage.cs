

using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class InspirationImage
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; } = null!;
        public Guid DesignerId { get; set; }
        public PatternMaker Designer { get; set; } = null!;
        
        // maybe we need position of image 
    }
}
