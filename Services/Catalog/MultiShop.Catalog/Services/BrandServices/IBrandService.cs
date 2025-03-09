using MultiShop.Catalog.Dtos.BrandDtos;

namespace MultiShop.Catalog.Services.BrandServices;

public interface IBrandService
{
    Task<List<ResultBrandDto>> GetAllBrandsAsync();
    Task<GetByIdBrandDto> GetBrandByIdAsync(string brandId);
    Task CreateBrandAsync(CreateBrandDto createBrandDto);
    Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
    Task DeleteBrandAsync(string brandId);
}