using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices;

public class FeatureSliderService : IFeatureSliderService
{
    private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
    private readonly IMapper _mapper;

    public FeatureSliderService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _featureSliderCollection = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
        _mapper = mapper;
    }

    public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createCategoryDto)
    {
        var featureSlider = _mapper.Map<FeatureSlider>(createCategoryDto);
        await _featureSliderCollection.InsertOneAsync(featureSlider);
    }

    public async Task DeleteFeatureSliderAsync(string featureSliderId)
    {
        await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderId == featureSliderId);
    }

    public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
    {
        var featureSliders = await _featureSliderCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultFeatureSliderDto>>(featureSliders);
    }

    public async Task<GetFeatureSliderByIdDto> GetFeatureSliderByIdAsync(string featureSliderId)
    {
        var featureSlider = await _featureSliderCollection.Find(x => x.FeatureSliderId == featureSliderId).FirstOrDefaultAsync();
        return _mapper.Map<GetFeatureSliderByIdDto>(featureSlider);
    }

    public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateCategoryDto)
    {
        var featureSlider = _mapper.Map<FeatureSlider>(updateCategoryDto);
        await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == updateCategoryDto.FeatureSliderId, featureSlider);
    }

    public async Task ChangeFeatureSliderStatus(string featureSliderId, bool status)
    {
        var filter = Builders<FeatureSlider>.Filter.Eq(x => x.FeatureSliderId, featureSliderId);
        var update = Builders<FeatureSlider>.Update.Set(x => x.Status, status);
        await _featureSliderCollection.UpdateOneAsync(filter, update);
    }
}