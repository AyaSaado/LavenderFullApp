﻿

using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class FinancialMatters
    {
        [Key]
        public int Id { get; set; }
        public decimal Executive_Salary { get; set; }
        public decimal Executive_Profit { get; set; }
        public decimal Designer_Salary{ get; set; }
        public decimal Tailor_Salary { get; set; }
        public ICollection<DisscountRange> Disscount_Range { get; set; } = new List<DisscountRange>();  
    }
}
