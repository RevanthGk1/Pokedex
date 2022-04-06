using Microsoft.Extensions.Caching.Memory;

namespace Pokedex.Cache
{
    public class CacheManager
    {
        private IMemoryCache _memoryCache;

        private readonly MemoryCacheEntryOptions _cacheOptions;

        public CacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _cacheOptions = new MemoryCacheEntryOptions()
                               .SetSlidingExpiration(TimeSpan.FromMinutes(10))
                               .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));
        }

        public object Get(string name)
        {
            return _memoryCache.Get(name);
        }

        public void Set(string name, object obj)
        {
            _memoryCache.Set(name,obj, _cacheOptions);
        }

        public void Remove(string name)
        {
            _memoryCache.Remove(name);
        }
    }
}
