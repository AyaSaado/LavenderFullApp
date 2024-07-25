using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using MediatR;
using System.Linq.Expressions;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.SewingMachines
{
    public class GetAllSewingMachinesRequest : IRequest<List<SewingMachineResponse>>
    {
        public Guid? ProductionEmpId { get; set; }
        public int MachineNameId { get; set; }
    }
    public class SewingMachineResponse
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public ModelNameDto ModelNameDto { get; set; } = null!;
        public Guid ProductionEmpId { get; set; }
        public bool Active { get; set; }

        public static Expression<Func<SewingMachine, SewingMachineResponse>> Selector() => p
            => new()
            {
                Id = p.Id,
                Code = p.Code,
                Active = p.Active,
                ProductionEmpId = p.ProductionEmpId,
                PurchaseDate = p.PurchaseDate,
                ModelNameDto = Mapping.Mapper.Map<ModelNameDto>(p.ModelName) 
            };
    }
}
