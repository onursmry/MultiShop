using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices;

public interface IProductImageService
{
    Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
    Task<GetByIdProductImageDto> GetProductImageByIdAsync(string productImageId);
    Task<GetByIdProductImageDto> GetProductImageByProductIdAsync(string productId);
    Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
    Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
    Task DeleteProductImageAsync(string productImageId);
}