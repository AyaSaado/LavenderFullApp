

using Lavender.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class DesignImage
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ImageType ImageType { get; set; }
        public int DesignId { get; set; }
        public Design Design { get; set; } = null!;
        
    }
}
