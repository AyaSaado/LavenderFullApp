

using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.Designs
{
    public class GetDesignImageUrlHandler : IRequestHandler<GetDesignImageUrlRequest, string>
    {
        public ICRUDRepository<DesignImage> _designImageRepository { get; set; }

        public GetDesignImageUrlHandler(ICRUDRepository<DesignImage> designImageRepository)
        {
            _designImageRepository = designImageRepository;
        }

        public async Task<string> Handle(GetDesignImageUrlRequest request, CancellationToken cancellationToken)
        {
            var result = await _designImageRepository.Find(d => d.DesignId == request.GalleryDesignId)
                                                     .FirstOrDefaultAsync(cancellationToken);
            
            if(result != null)
            return result.Url;

            return string.Empty;
        }
    }
}
