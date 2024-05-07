using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResultCouponDto>>> CouponList()
        {
            var coupons = await _discountService.GetAllCouponsAsync();
            return Ok(coupons);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCouponAsync(createCouponDto);
            return Ok();
        }

        [HttpGet("{couponId}")]
        public async Task<ActionResult<ResultCouponDto>> GetByIdCouponAsync(int couponId)
        {
            var coupon = await _discountService.GetByIdCouponAsync(couponId);
            return Ok(coupon);
        }

        [HttpPut("{couponId}")]
        public async Task<ActionResult> UpdateCouponAsync(int couponId, CreateCouponDto createCouponDto)
        {
            await _discountService.UpdateCouponAsync(couponId, createCouponDto);
            return Ok();
        }

        [HttpDelete("{couponId}")]
        public async Task<ActionResult> DeleteCouponAsync(int couponId)
        {
            await _discountService.DeleteCouponAsync(couponId);
            return Ok();
        }
    }
}
