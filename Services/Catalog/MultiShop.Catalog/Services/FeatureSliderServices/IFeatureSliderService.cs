using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Services.FeatureSliderServices;

public interface IFeatureSliderService
{
    Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
    Task<GetFeatureSliderByIdDto> GetFeatureSliderByIdAsync(string featureSliderId);
    Task CreateFeatureSliderAsync(CreateFeatureSliderDto createCategoryDto);
    Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateCategoryDto);
    Task DeleteFeatureSliderAsync(string featureSliderId);
    Task ChangeFeatureSliderStatus(string featureSliderId, bool status);
}