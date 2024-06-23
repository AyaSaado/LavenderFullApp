using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.Designs
{
    public class AddDesignRequest : IRequest<bool>
    {
        public string Title { get; set; } = null!;
        public decimal Height { get; set; }
        public Guid DesignerId { get; set; }
        public int OrderId { get; set; }
        public ICollection<DesignImageDto> DesignImageDtos { get; set; } = new List<DesignImageDto>();
        public ICollection<FabricDesignDto> FabricDesignDtos { get; set; } = new List<FabricDesignDto>();
        public ICollection<DesignAccessoryDto> DesignAccessoryDtos { get; set;} = new List<DesignAccessoryDto>();

    }
}
