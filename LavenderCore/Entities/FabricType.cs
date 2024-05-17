

using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class FabricType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<FabricDesign> FabricDesigns { get; set; }= new List<FabricDesign>();  
    }
}
