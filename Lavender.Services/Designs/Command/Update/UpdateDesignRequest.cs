using Lavender.Core.EntityDto;
using Lavender.Core.Shared;
using MediatR;

namespace Lavender.Services.Designs
{
    public class UpdateDesignRequest :IRequest<Result>
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Height { get; set; }
        public decimal Discount { get; set; }
        public Guid? ProductionLineId { get; set; }
        public Guid? TailorId { get; set; }
        public Guid DesignerId { get; set; }
        public ICollection<DesignImageDto> DesignImageDtos { get; set; } = new List<DesignImageDto>();
        public ICollection<FabricDesignDto> FabricDesignDtos { get; set; } = new List<FabricDesignDto>();
        public ICollection<DesignAccessoryDto> DesignAccessoryDtos { get; set; } = new List<DesignAccessoryDto>();

    }
}
