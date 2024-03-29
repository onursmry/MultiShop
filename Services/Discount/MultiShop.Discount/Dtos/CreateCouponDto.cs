namespace MultiShop.Discount.Dtos;

public class CreateCouponDto
{
    public string CouponCode { get; set; }
    public int DiscountRate { get; set; }
    public bool IsActive { get; set; }
    public DateTime ValidDate { get; set; }
}