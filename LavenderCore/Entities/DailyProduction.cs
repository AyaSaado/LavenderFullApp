using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class DailyProduction
    {
        [Key]
        public int Id { get; set; }
        public DateOnly Day { get; set; }
        public TimeSpan WorkHours { get; set; }
        public int WorkQuantity { get; set;}
        public int WorkerId { get; set; }
        public SewingMachine Worker { get; set; } = null!;
    }
}
