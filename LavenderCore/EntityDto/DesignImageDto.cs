using Lavender.Core.Enum;
using Microsoft.AspNetCore.Http;

namespace Lavender.Core.EntityDto
{
    public class DesignImageDto
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public IFormFile? Image { get; set; }
        public ImageType ImageType { get; set; }
    }
}
