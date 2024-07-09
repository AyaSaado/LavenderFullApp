using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.Designs
{
    public class AddDesignRequest : IRequest<bool>
    {
        public string? Description { get; set; } 
        public decimal Height { get; set; }
        public decimal Discount { get; set; }
        public decimal DesignPrice { get; set; }
        public Guid DesignerId { get; set; }
        public int OrderId { get; set; }
        public ICollection<DesignImageDto> DesignImageDtos { get; set; } = new List<DesignImageDto>();

    }
}
