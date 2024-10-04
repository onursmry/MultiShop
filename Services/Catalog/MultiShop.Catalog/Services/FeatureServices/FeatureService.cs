using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices;

public class FeatureService : IFeatureService
{
    private readonly IMongoCollection<Feature> _featureCollection;
    private readonly IMapper _mapper;

    public FeatureService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _featureCollection = database.GetCollection<Feature>(databaseSettings.FeatureCollectionName);
        _mapper = mapper;
    }

    public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
    {
        var feature = _mapper.Map<Feature>(createFeatureDto);
        await _featureCollection.InsertOneAsync(feature);
    }

    public async Task DeleteFeatureAsync(string featureId)
    {
        await _featureCollection.DeleteOneAsync(x => x.FeatureId == featureId);
    }

    public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
    {
        var feature = _mapper.Map<Feature>(updateFeatureDto);
        await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == updateFeatureDto.FeatureId, feature);
    }

    public async Task<List<ResultFeatureDto>> GetAllCategoriesAsync()
    {
        var features = await _featureCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultFeatureDto>>(features);
    }

    public async Task<GetFeatureByIdDto> GetFeatureByIdAsync(string featureId)
    {
        var feature = await _featureCollection.Find(x => x.FeatureId == featureId).FirstOrDefaultAsync();
        return _mapper.Map<GetFeatureByIdDto>(feature);
    }
}