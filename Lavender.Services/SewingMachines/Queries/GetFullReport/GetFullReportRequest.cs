using MediatR;

namespace Lavender.Services.SewingMachines
{
    public class GetFullReportRequest : IRequest<ProductionReport>
    {
        public Guid ProductionId { get; set; }
        public DateOnly FromDate { get; set; } = DateOnly.FromDateTime(DateTime.Now).AddMonths(-1);
        public DateOnly ToDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);          
    }

    public class ProductionReport
    {
        public int TotalEmps {  get; set; }
        public int TotalMachines { get; set; }
        public decimal ProductivityOfMachines { get; set; }
        public decimal ProductivityOfWorker { get; set; }

        public List<ProductivityOfStep> ProductivityOfStep { get; set; } = new List<ProductivityOfStep>();
    }

    public class ProductivityOfStep
    {
        public int StepId {  get; set; }
        public int ItemQuantity { get; set; }
        public int OrdersCount { get; set; }

    }
}
