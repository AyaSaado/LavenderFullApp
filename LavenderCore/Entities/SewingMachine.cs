using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class SewingMachine
    {
        [Key]
        public int Id { get; set; }
        public int Code { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public ProductionEmp ProductionEmp { get; set; } = null!;
        public ModelName ModelName { get; set; } = null!;
        public ICollection<DailyProduction> DailyProductions { get; set;} = new List<DailyProduction>();
    }
}
