using Microsoft.Extensions.Caching.Memory;

namespace Pokedex.Cache
{
    public class TranslatedCacheManager
    {
        private IMemoryCache _translatedMemoryCache;

        private readonly MemoryCacheEntryOptions _cacheOptions;

        public TranslatedCacheManager(IConfiguration configuration)
        {
            if (_translatedMemoryCache == null)
                _translatedMemoryCache = new MemoryCache(new MemoryCacheOptions());

            int sldTime = configuration["cacheSlideTimeMins"] != null ? Convert.ToInt32(configuration["cacheSlideTimeMins"]) : 10;
            int expTime = configuration["CacheExpiryTimeMins"] != null ? Convert.ToInt32(configuration["CacheExpiryTimeMins"]) : 30;

            _cacheOptions = new MemoryCacheEntryOptions()
                               .SetSlidingExpiration(TimeSpan.FromMinutes(sldTime))
                               .SetAbsoluteExpiration(TimeSpan.FromMinutes(expTime));
        }

        public object Get(string name)
        {
            return _translatedMemoryCache.Get(name);
        }

        public void Set(string name, object obj)
        {
            _translatedMemoryCache.Set(name, obj, _cacheOptions);
        }

        public void Remove(string name)
        {
            _translatedMemoryCache.Remove(name);
        }
    }
}
