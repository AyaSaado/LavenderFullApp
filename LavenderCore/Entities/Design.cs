using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class Design
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; } 
        public decimal Height  { get; set; }
        public decimal Discount { get; set; }
        public decimal DesignPrice { get; set; }
        public Guid? ProductionLineId { get; set; }
        public Guid? TailorId { get; set; }
        public Guid DesignerId { get; set; }
        public int OrderId { get; set; }
        public ProductionEmp? ProductionLine { get; set; }
        public PatternMaker? Tailor { get; set; }
        public PatternMaker Designer { get; set; } = null!;
        public Order Order { get; set; } = null!;
        public ICollection<DesignImage> DesignImages { get; set; } = new List<DesignImage>();
        public ICollection<Consuming> Consumings { get; set; } = new List<Consuming>();
        public ICollection<Chat> Chats { get; set; } = new List<Chat>();
        public void Update(string? description, decimal height , decimal discount,decimal designPrice,
                               Guid? productionLineId , Guid? tailorId,
                                          Guid designerId)
        {
            Description = description;
            Height = height;
            Discount = discount;
            DesignPrice = designPrice;
            ProductionLineId = productionLineId;
            TailorId = tailorId;    
            DesignerId = designerId;
        }
    }
}
