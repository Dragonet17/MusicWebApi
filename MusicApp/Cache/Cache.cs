using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace MusicApp.Cache
{
    public class MemoryCacher
    {

        public enum DateToCache
        {
            Songs,Artists,Albums,AlbumsSongs
        }
        public object GetValue(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Get(key);
        }

        public bool Add(string key, object value, DateTimeOffset absExpiration)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, absExpiration);
        }

        public void Delete(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(key))
            {
                memoryCache.Remove(key);
            }
        }

        public bool IfCacheExsist(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            var cache = memoryCache.Get(key);
            return cache != null;
        }

        public void ClearCache(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            
            if (IfCacheExsist(key))
            {
                Delete(key);
            }
        }
    }
}