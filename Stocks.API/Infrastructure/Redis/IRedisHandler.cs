using Microsoft.Extensions.Primitives;
using StackExchange.Redis;
using System.Text.Json;

namespace Stocks.API.Infrastructure.Redis;

public interface IRedisHandler
{
    Task<T>? GetValueByKeyAsync<T>(string key) where T : class;
    Task SaveAsync<T>(string key, T value, RedisSaveTimeOptions option) where T : class;
}

public class RedisHandler : IRedisHandler
{
    private readonly IDatabase _redisDatabase;

    public RedisHandler(IConnectionMultiplexer connectionMultipler)
    {
        _redisDatabase = connectionMultipler.GetDatabase();
    }

    public async Task<T>? GetValueByKeyAsync<T>(string key) where T : class
    {
        var str = await _redisDatabase.StringGetAsync(key);

        if (str == RedisValue.Null || str == RedisValue.EmptyString)
            return null;

        return JsonSerializer.Deserialize<T>(str);
    }
    public async Task SaveAsync<T>(string key, T value, RedisSaveTimeOptions option) where T : class
    {
        TimeSpan timeSpan = new TimeSpan((int)option * TimeSpan.TicksPerMinute);

        await _redisDatabase.StringSetAsync(key, JsonSerializer.Serialize(value), timeSpan);
    }
}

public enum RedisSaveTimeOptions
{
    FIVE_MINUTES = 5,
    FIFTEN_MINUTES = 15,
    THRITY_MINUTES = 30,
    ONE_HOUR = 60
}

