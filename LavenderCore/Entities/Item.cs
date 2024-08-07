﻿using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Discount { get; set; }
        public  ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
