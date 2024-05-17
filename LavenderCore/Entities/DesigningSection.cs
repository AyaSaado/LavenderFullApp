

using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class DesigningSection
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<MakerSection> MakerSections { get; set; } = new List<MakerSection>();

    }
}
