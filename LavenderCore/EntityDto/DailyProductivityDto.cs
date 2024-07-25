
namespace Lavender.Core.EntityDto
{
    public class DailyProductivityDto
    {
        public int Id { get; set; }
        public DateOnly Day { get; set; }
        public TimeSpan WorkHours { get; set; }
        public int WorkQuantity { get; set; }
        public int WorkerId { get; set; }
    }
}
