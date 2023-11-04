using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{
    public class FunctionCache<TKey, TResult>
        where TKey : notnull
    {
        private readonly Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();
        private readonly TimeSpan defaultCacheDuration = TimeSpan.FromMinutes(10);
        private readonly object cacheLock = new object();

        public delegate TResult FuncDelegate(TKey key);

        public FunctionCache()
        {
        }

        public FunctionCache(TimeSpan defaultCacheDuration)
        {
            this.defaultCacheDuration = defaultCacheDuration;
        }

        public TResult GetOrAdd(TKey key, FuncDelegate func, TimeSpan? cacheDuration = null)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            lock (cacheLock)
            {
                if (cache.TryGetValue(key, out CacheItem? cachedItem) && cachedItem != null && !IsCacheItemExpired(cachedItem))
                {
                    return cachedItem.Result;
                }

                TResult result = func(key);
                cache[key] = new CacheItem(result, cacheDuration ?? defaultCacheDuration);
                return result;
            }
        }

        private bool IsCacheItemExpired(CacheItem cacheItem)
        {
            return DateTime.Now - cacheItem.Timestamp >= cacheItem.CacheDuration;
        }

        private class CacheItem
        {
            public TResult Result { get; }
            public TimeSpan CacheDuration { get; }
            public DateTime Timestamp { get; }

            public CacheItem(TResult result, TimeSpan cacheDuration)
            {
                Result = result;
                CacheDuration = cacheDuration;
                Timestamp = DateTime.Now;
            }
        }
    }
}
