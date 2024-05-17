

using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class Factory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address {  get; set; } = null!;
        public string Phone { get; set; } = null!;
        public ICollection<Purchase> Purchases { get; set; } =new List<Purchase>();

    }
}
