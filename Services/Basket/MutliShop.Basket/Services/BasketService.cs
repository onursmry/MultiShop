using System.Text.Json;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            var existingBasket = await _redisService.GetDb().StringGetAsync(userId);
            return existingBasket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<BasketTotalDto>(existingBasket);
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }

        public async Task DeleteBasket(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);
        }
    }
}
