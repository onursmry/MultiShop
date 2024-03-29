using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public class DiscountService:IDiscountService
{
    private readonly DapperContext _context;
    private readonly 

    public DiscountService(DapperContext context)
    {
        _context = context;
    }

    public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
    {
        string query = @"SELECT * FROM Coupons";
        return (await _context.CreateConnection().QueryAsync<ResultCouponDto>(query)).ToList();
    }

    public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
    {
        string query =@"INSERT INTO Coupons (CouponCode, DiscountRate, IsActive, ValidDate) VALUES (@CouponCode, @DiscountRate, @IsActive, @ValidDate)";
        await _context.CreateConnection().ExecuteAsync(query, new {createCouponDto});
    }

    public Task<ResultCouponDto> GetByIdCouponAsync(int couponId)
    {
        string query = @"SELECT * FROM Coupons WHERE CouponId = @CouponId";
        return _context.CreateConnection().QueryFirstOrDefaultAsync<ResultCouponDto>(query, new {CouponId = couponId});
    }

    public Task UpdateCouponAsync(int couponId, CreateCouponDto createCouponDto)
    {
        string query = @"UPDATE Coupons SET CouponCode = @CouponCode, DiscountRate = @DiscountRate, IsActive = @IsActive, ValidDate = @ValidDate WHERE CouponId = @CouponId";
        return _context.CreateConnection().ExecuteAsync(query, new {createCouponDto, CouponId = couponId});
    }

    public Task DeleteCouponAsync(int couponId)
    {
       string query = @"DELETE FROM Coupons WHERE CouponId = @CouponId";
       return _context.CreateConnection().ExecuteAsync(query, new {CouponId = couponId});
    }
}