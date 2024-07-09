using Lavender.Core.EntityDto;
using Lavender.Core.Shared;
using MediatR;

namespace Lavender.Services.Designs
{
    public class UpdateDesignRequest :IRequest<Result>
    {
        public int Id { get; set; }
        public string? Description { get; set; } 
        public decimal Height { get; set; }
        public decimal Discount { get; set; }
        public decimal DesignPrice { get; set; }
        public Guid? ProductionLineId { get; set; }
        public Guid? TailorId { get; set; }
        public Guid DesignerId { get; set; }
        public ICollection<DesignImageDto> DesignImageDtos { get; set; } = new List<DesignImageDto>();
        

    }
}
