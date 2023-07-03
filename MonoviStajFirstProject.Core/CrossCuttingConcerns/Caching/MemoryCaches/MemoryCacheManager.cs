﻿using System;
using System.Runtime.Caching;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MonoviStajFirstProject.Core.CrossCuttingConcerns.Caching.MemoryCaches
{
    public class MemoryCacheManager : ICacheManager
    {

        protected ObjectCache Cache => MemoryCache.Default;

        public void Add(string key, object data, int cacheTime)
        {
            if (data == null)
            {
                return;
            }

            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.UtcNow + TimeSpan.FromMinutes(cacheTime) };
            Cache.Add(new CacheItem(key,data),policy);


        }

        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item);
            }
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public bool IsAdd(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);

            var keysRemove = Cache.Where(p => regex.IsMatch(p.Key)).Select(p => p.Key).ToList();

            foreach (var key in keysRemove)
            {
                Remove(key);
            }

        }
    }
}
