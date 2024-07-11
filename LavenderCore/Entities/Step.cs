using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class Step
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!; 
        public ICollection<Plan> Plans { get; set;} = new List<Plan>();

    }
}
