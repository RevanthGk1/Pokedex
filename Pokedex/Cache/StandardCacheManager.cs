using Microsoft.Extensions.Caching.Memory;

namespace Pokedex.Cache
{
    public class StandardCacheManager
    {
        private IMemoryCache _standardMemoryCache;

        private readonly MemoryCacheEntryOptions _cacheOptions;

        public StandardCacheManager(IConfiguration configuration)
        {
            if(_standardMemoryCache == null)
                _standardMemoryCache = new MemoryCache(new MemoryCacheOptions());

            int sldTime = configuration["cacheSlideTimeMins"] != null ? Convert.ToInt32(configuration["cacheSlideTimeMins"]) : 10;
            int expTime = configuration["CacheExpiryTimeMins"] != null ? Convert.ToInt32(configuration["CacheExpiryTimeMins"]) : 30;

            _cacheOptions = new MemoryCacheEntryOptions()
                               .SetSlidingExpiration(TimeSpan.FromMinutes(sldTime))
                               .SetAbsoluteExpiration(TimeSpan.FromMinutes(expTime));
        }

        public object Get(string name)
        {
            return _standardMemoryCache.Get(name);
        }

        public void Set(string name, object obj)
        {
            _standardMemoryCache.Set(name,obj, _cacheOptions);
        }

        public void Remove(string name)
        {
            _standardMemoryCache.Remove(name);
        }

    }
}
