using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.SewingMachines
{
    public class UpdateSewingMachineRequest : IRequest<bool>
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public Guid? ModelNameId { get; set; } 
        public Guid ProductionEmpId { get; set; }
        public bool Active { get; set; }

    }
}
