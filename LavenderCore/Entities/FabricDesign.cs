using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class FabricDesign
    {
        [Key]
        public int Id { get; set; }
        public decimal FabricWidth { get; set; }
        public decimal FabricHeight { get; set;}
        public string Purpose { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int FabricTypeId { get; set; }
        public FabricType FabricType { get; set; } = null!;
        public int DesignId { get; set; }
        public Design Design { get; set; } = null!; 

    }
}
