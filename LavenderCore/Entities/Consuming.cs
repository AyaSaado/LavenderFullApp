using Lavender.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class Consuming
    {
        [Key]
        public int Id { get; set; }
        public decimal QuantityOrdered { get; set; }
        public TypeOfUnit TypeOfUnit { get; set; }
        public DateOnly DateOfDemand { get; set; }
        public int DesignId { get; set; }
        public int SItemTypeId { get; set; }
        public Design Design { get; set; } = null!;
        public SItemType SItemType { get; set; } = null!;
        
    }
}
