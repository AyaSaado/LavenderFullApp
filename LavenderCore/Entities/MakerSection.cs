

using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class MakerSection
    {
        [Key]
        public int Id { get; set; }
        public int DesigningSectionId { get; set; }
        public Guid PatternMakerId { get; set; }
        public PatternMaker PatternMaker { get; set; } = null!;
        public DesigningSection DesigningSection { get; set; } = null!;
    }
}
