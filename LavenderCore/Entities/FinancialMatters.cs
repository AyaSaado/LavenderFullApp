

using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class FinancialMatters
    {
        [Key]
        public int Id { get; set; }
        public decimal PieceProfit { get; set; }
        public decimal Executive_Wage { get; set; }
        public decimal Executive_Profit { get; set; }
        public decimal Worker_Wage { get; set; }
        public decimal ProductionManager_Wage { get; set; }


    }
}
