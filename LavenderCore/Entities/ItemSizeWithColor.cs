﻿using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class ItemSizeWithColor
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Color { get; set; } = null!;
        public int ItemSizeId { get; set; }
        public ItemSize ItemSize { get; set; } = null!;
        public ICollection<Plan> Plans { get; set; } = new List<Plan>();
    }
}
