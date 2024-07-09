using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Localization;

namespace LavenderFullApp.Localization
{
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly IDistributedCache _cache;
          private readonly IHttpContextAccessor _httpContextAccessor;
        public JsonStringLocalizerFactory(IDistributedCache cache, IHttpContextAccessor httpContextAccessor)
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return new JsonStringLocalizer(_cache, _httpContextAccessor);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new JsonStringLocalizer(_cache, _httpContextAccessor);
        }
    }

}
