
using AutoMapper;
using BookHavenWebAPI.Core.Abstractions;
using StackExchange.Redis;

namespace BookHavenWebAPI.Buisness.Services
{
    public class RedisCacheService : IRedisCacheService
    {

        private readonly IDatabase redisDB;
          
        public RedisCacheService(IConnectionMultiplexer redis)
        { 
            redisDB = redis.GetDatabase();
        }

        public async Task SetAsync(string key, string value, TimeSpan? expiry = null)
        {
            await redisDB.StringSetAsync(key, value, expiry);
        }

        public async Task<string?> GetAsync(string key)
        {
            var value = await redisDB.StringGetAsync(key);
            return value.HasValue ? (string?)value : null;
        }

        public async Task RemoveAsync(string key)
        {
            await redisDB.KeyDeleteAsync(key);
        }

    }
}
