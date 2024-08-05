using Lavender.Core.Enum;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lavender.Core.Entities
{
    public class Consuming
    {
        [Key]
        public int Id { get; set; }
        public decimal QuantityOrdered { get; set; }
        public TypeOfUnit TypeOfUnit { get; set; }
        public DateOnly DateOfDemand { get; set; }
        public int OrderId { get; set; }
        public int SItemTypeId { get; set; }
        public Order Order { get; set; } = null!;
        public SItemType SItemType { get; set; } = null!;
       
        [NotMapped] 
        public List<string>? Colors { get; set; } = new List<string>();

        [Column("Colors")]
        public string SerializedColors
        {
            get => JsonConvert.SerializeObject(Colors);
            set => Colors = JsonConvert.DeserializeObject<List<string>>(value);
        }
    }
}
