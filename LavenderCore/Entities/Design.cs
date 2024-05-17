

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class Design
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Title { get; set; } = null!;
        public decimal Height  { get; set; }
        public decimal Discount { get; set; }
        public ProductionEmp? ProductionLine { get; set; }
        public PatternMaker? Tailor { get; set; }
        public PatternMaker Designer { get; set; } = null!;
        public Order Order { get; set; } = null!;
        public ICollection<DesignImage> DesignImages { get; set; } = new List<DesignImage>();
        public ICollection<FabricDesign> Fabrics { get; set; } = new List<FabricDesign>();
        public ICollection<Consuming> Consumings { get; set; } = new List<Consuming>();
        public ICollection<Chat> Chats { get; set; } = new List<Chat>();

    }
}
