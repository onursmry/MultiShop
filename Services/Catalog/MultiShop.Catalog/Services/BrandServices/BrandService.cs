using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices;

public class BrandService : IBrandService
{
    private readonly IMongoCollection<Brand> _brandCollection;
    private readonly IMapper _mapper;

    public BrandService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _brandCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
        _mapper = mapper;
    }

    public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
    {
        var brand = _mapper.Map<Brand>(createBrandDto);
        await _brandCollection.InsertOneAsync(brand);
    }

    public async Task<List<ResultBrandDto>> GetAllBrandsAsync()
    {
        var brands = await _brandCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultBrandDto>>(brands);
    }

    public async Task<GetByIdBrandDto> GetBrandByIdAsync(string brandId)
    {
        var brand = await _brandCollection.Find(x => x.BrandId == brandId).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdBrandDto>(brand);
    }

    public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
    {
        var brand = _mapper.Map<Brand>(updateBrandDto);
        await _brandCollection.FindOneAndReplaceAsync(x => x.BrandId == updateBrandDto.BrandId, brand);
    }

    public async Task DeleteBrandAsync(string brandId)
    {
        await _brandCollection.DeleteOneAsync(x => x.BrandId == brandId);
    }
}