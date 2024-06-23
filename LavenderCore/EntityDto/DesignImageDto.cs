using Lavender.Core.Enum;

namespace Lavender.Core.EntityDto
{
    public class DesignImageDto
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; } 
        public ImageType ImageType { get; set; }
    }
}
