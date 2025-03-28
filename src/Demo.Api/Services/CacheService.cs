using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Demo.Api.Services
{
    public interface ICacheService
    {
        Task<T> GetRecordAsync<T>(string key);
        Task SetRecordAsync<T>(string key, T data, DateTimeOffset? absouteExpireTime = null);
    }

    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetRecordAsync<T>(string key)
        {
            var jsonData = await _cache.GetStringAsync(key);

            if (jsonData == null) return default;

            return JsonSerializer.Deserialize<T>(jsonData);
        }

        public async Task SetRecordAsync<T>(string key, T data, DateTimeOffset? absoluteExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = absoluteExpireTime ?? DateTimeOffset.Now.AddMinutes(1)
            };

            var jsonData = JsonSerializer.Serialize(data);

            await _cache.SetStringAsync(key, jsonData, options);
        }
    }
}
