
using Lavender.Core.Entities;
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class UpsertFinancialMattersRequest : IRequest<bool>
    {
        public int Id { get; set; }
        public decimal Executive_Salary { get; set; }
        public decimal Executive_Profit { get; set; }
        public decimal Designer_Salary { get; set; }
        public decimal Tailor_Salary { get; set; }
        public ICollection<DisscountRange> Disscount_Range { get; set; } = new List<DisscountRange>();
    }
   
}
