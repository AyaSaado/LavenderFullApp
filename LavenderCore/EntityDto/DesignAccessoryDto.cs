using Lavender.Core.Enum;

namespace Lavender.Core.EntityDto
{
    public class DesignAccessoryDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public TypeOfUnit TypeOfUnit { get; set; }
        public string Color { get; set; } = null!;
        public int AccessoryId { get; set; }
    }
}
