﻿using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos;

public class ProductResultWithCategoryDto
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public string ProductImageUrl { get; set; }
    public string ProductDescription { get; set; }
    public string CategoryId { get; set; }
    public CategoryResultDto Category { get; set; }
}