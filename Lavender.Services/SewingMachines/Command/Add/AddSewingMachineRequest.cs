using MediatR;

namespace Lavender.Services.SewingMachines
{
    public class AddSewingMachineRequest : IRequest<bool>
    {
        public int Code { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public Guid ProductionEmpId { get; set; }
        public int ModelNameId { get; set; } 
    }
  
}
