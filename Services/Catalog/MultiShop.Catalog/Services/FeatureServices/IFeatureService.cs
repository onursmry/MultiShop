using MultiShop.Catalog.Dtos.FeatureDtos;

namespace MultiShop.Catalog.Services.FeatureServices;

public interface IFeatureService
{
    Task<List<ResultFeatureDto>> GetAllCategoriesAsync();
    Task<GetFeatureByIdDto> GetFeatureByIdAsync(string featureId);
    Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
    Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
    Task DeleteFeatureAsync(string featureId);
}