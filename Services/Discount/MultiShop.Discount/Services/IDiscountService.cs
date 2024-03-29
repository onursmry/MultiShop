using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public interface IDiscountService
{
    Task<List<ResultCouponDto>> GetAllCouponsAsync();
    Task CreateCouponAsync(CreateCouponDto createCouponDto);
    Task<ResultCouponDto> GetByIdCouponAsync(int couponId);
    Task UpdateCouponAsync(int couponId, CreateCouponDto createCouponDto);
    Task DeleteCouponAsync(int couponId);
}