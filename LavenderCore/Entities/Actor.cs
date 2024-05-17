namespace Lavender.Core.Entities
{
    public class Actor : User
    {
        public bool VIP {  get; set; }
        public  ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
