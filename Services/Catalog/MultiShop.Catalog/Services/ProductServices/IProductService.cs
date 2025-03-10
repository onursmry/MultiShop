﻿using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices;

public interface IProductService
{
    Task<List<ResultProductDto>> GetAllProductsAsync();
    Task<GetByIdProductDto> GetProductByIdAsync(string productId);
    Task CreateProductAsync(CreateProductDto createProductDto);
    Task UpdateProductAsync(UpdateProductDto updateProductDto);
    Task DeleteProductAsync(string productId);
    Task<List<ResultProductsWithCategoryDto>> GetAllProductsWithCategoryAsync();
    Task<List<ResultProductsWithCategoryDto>> GetAllProductsWithCategoryByCategoryIdAsync(string categoryId);
}