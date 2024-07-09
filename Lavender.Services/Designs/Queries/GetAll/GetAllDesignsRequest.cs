
using Lavender.Core.Entities;
using Lavender.Core.Enum;
using MediatR;
using System.Linq.Expressions;

namespace Lavender.Services.Designs
{
    public class GetAllDesignsRequest : IRequest<List<AllDesignsResponse>>
    {
        public int ItemTypeId { get; set; } = 0;
        public int ItemId { get; set; } = 0;
    }
    public class AllDesignsResponse
    {
        public int Id { get; set; }
        public decimal Discount { get; set; }
        public decimal DesignPrice { get; set; }
        public string DesignImageUrl { get; set; } = null!;
        public string ItemName { get; set; } = null!;
        public int ItemId { get; set; } 
        public int ItemTypeId { get; set; }


        public static Expression<Func<Design, AllDesignsResponse>> Selector() => c
              => new()
              {
                  Id = c.Id,
                  ItemName = c.Order.Item.Name,
                  ItemId = c.Order.ItemId,
                  ItemTypeId = c.Order.ItemTypeId,
                  DesignPrice = c.DesignPrice,
                  Discount = c.Discount,
                  DesignImageUrl = c.DesignImages.Where(im=>im.ImageType == ImageType.model).First().Url

              };
    }
}
