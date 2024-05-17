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
        public SewingMachine WorkerId { get; set; } = null!;
    }
}
