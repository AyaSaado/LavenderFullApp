using Lavender.Core.Enum;

namespace Lavender.Core.EntityDto
{
    public class ConsumingDto
    {
        public int Id { get; set; }
        public decimal QuantityOrdered { get; set; }
        public TypeOfUnit TypeOfUnit { get; set; }
        public DateOnly DateOfDemand { get; set; }
        public int OrderId { get; set; }
        public int SItemTypeId { get; set; }
    }
}
