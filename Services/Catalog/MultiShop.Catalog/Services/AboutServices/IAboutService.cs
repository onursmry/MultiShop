using MultiShop.Catalog.Dtos.AboutDtos;

namespace MultiShop.Catalog.Services.AboutServices;

public interface IAboutService
{
    Task<List<ResultAboutDto>> GetAllAboutsAsync();
    Task<GetByIdAboutDto> GetAboutByIdAsync(string aboutId);
    Task CreateAboutAsync(CreateAboutDto createAboutDto);
    Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
    Task DeleteAboutAsync(string aboutId);
}