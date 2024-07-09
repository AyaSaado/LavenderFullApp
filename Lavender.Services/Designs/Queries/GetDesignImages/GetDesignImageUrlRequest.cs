
using MediatR;

namespace Lavender.Services.Designs
{
    public class GetDesignImageUrlRequest : IRequest<string>
    {
        public int GalleryDesignId { get; set; }
    }
}
