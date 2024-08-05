using MediatR;

namespace Lavender.Services.Constants
{
    public class HomeReportRequest : IRequest<HomeResponse>
    {
      public DateOnly Date {  get; set; }
    }

    public class HomeResponse
    {
        public int CompletedOrders { get; set; }
        public int UnderWayOrders { get; set; }
        public int OurClients { get; set; }
        public int ProductionManagers { get; set; }
        public int ProductionWorkers { get; set; }
        public int Designers { get; set; }
        public int Tailors { get; set; }
        public int StoreManagers { get; set; }
        public List<int> DailyOrdersCounts { get; set; } = new List<int>();
    }
} 
