﻿namespace MultiShop.Discount.Entities;

public class Coupon
{
    public int CouponId { get; set; }
    public string CouponCode { get; set; }
    public int DiscountRate { get; set; }
    public bool IsActive { get; set; }
    public DateTime ValidDate { get; set; }
}