using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class Design
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Height  { get; set; }
        public decimal Discount { get; set; }
        public Guid? ProductionLineId { get; set; }
        public Guid? TailorId { get; set; }
        public Guid DesignerId { get; set; }
        public int OrderId { get; set; }
        public ProductionEmp? ProductionLine { get; set; }
        public PatternMaker? Tailor { get; set; }
        public PatternMaker Designer { get; set; } = null!;
        public Order Order { get; set; } = null!;
        public ICollection<DesignImage> DesignImages { get; set; } = new List<DesignImage>();
        public ICollection<FabricDesign> Fabrics { get; set; } = new List<FabricDesign>();
        public ICollection<DesignAccessory> Accessories { get; set; } = new List<DesignAccessory>();
        public ICollection<Consuming> Consumings { get; set; } = new List<Consuming>();
        public ICollection<Chat> Chats { get; set; } = new List<Chat>();
        public void Update(string title , decimal height , decimal discount,
                               Guid? productionLineId , Guid? tailorId,
                                          Guid designerId)
        {
            Title = title;
            Height = height;
            Discount = discount;
            ProductionLineId = productionLineId;
            TailorId = tailorId;    
            DesignerId = designerId;
        }
    }
}
