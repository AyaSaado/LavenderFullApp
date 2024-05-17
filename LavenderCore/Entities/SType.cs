using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class SType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<SItemType> SItemTypes { get; set; } = new List<SItemType>();
    }
}
