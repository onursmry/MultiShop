using StackExchange.Redis;

namespace MultiShop.Basket.Settings;

public class RedisService
{
    private readonly string _host;
    private readonly string _port;

    private ConnectionMultiplexer _redis;

    public RedisService(string host, string port)
    {
        _host = host;
        _port = port;
    }

    public void Connect() => _redis = ConnectionMultiplexer.Connect($"{_host}:{_port}");
    public IDatabase GetDb(int db = 1) => _redis.GetDatabase(0);
}