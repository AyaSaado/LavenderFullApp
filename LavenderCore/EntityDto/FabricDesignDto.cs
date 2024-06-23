

namespace Lavender.Core.EntityDto
{
    public class FabricDesignDto
    {
        public int Id { get; set; }
        public decimal FabricWidth { get; set; }
        public decimal FabricHeight { get; set; }
        public string? Purpose { get; set; }
        public string Color { get; set; } = null!; 
        public int FabricTypeId { get; set; }

    }
}
