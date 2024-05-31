using Lavender.Core.Enum;

namespace Lavender.Core.EntityDto
{
    public class ItemSizeDto
    {
        public int Id { get; set; }
        public Size Size { get; set; }
        public ICollection<ItemSizeWithColorDto> ItemSizeWithColorDtos { get; set; } = new List<ItemSizeWithColorDto>();

    }
}
