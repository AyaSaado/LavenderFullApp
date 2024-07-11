using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Enum;
using MediatR;
using System.Linq.Expressions;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Designs
{
    public class GetDesignByIdRequest : IRequest<OneDesignResponse?>
    {
        public int Id { get; set; }
    }
    public class OneDesignResponse
    {
        public int Id { get; set; }
        public decimal Discount { get; set; }
        public decimal DesignPrice { get; set; }
        public string? Description { get; set; }
        public decimal Height { get; set; }
        public Guid DesignerId { get; set; }
        public Guid? TailorId { get; set; }
        public int OrderId { get; set; }
        public List<string> UsedFabrics { get; set; } = new List<string>();
        public ICollection<DesignImageDto> DesignImageDtos { get; set; } = new List<DesignImageDto>();
        public ICollection<ItemSizeDto> ItemSizeDtos { get; set; } = new List<ItemSizeDto>();


        public static Expression<Func<Design, OneDesignResponse>> Selector() => c
              => new()
              {
                  Id = c.Id,
                  DesignPrice = c.DesignPrice,
                  Discount = c.Discount,
                  Description = c.Description,
                  Height = c.Height,
                  DesignerId = c.DesignerId,
                  TailorId = c.TailorId,
                  OrderId = c.OrderId,
                  DesignImageDtos = Mapping.Mapper.Map<List<DesignImageDto>>(c.DesignImages.Where(im => im.ImageType == ImageType.model)),
                 
              };
    }
}
