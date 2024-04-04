using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices;

public class ProductImageService : IProductImageService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<ProductImage> _productImageRepository;

    public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productImageRepository = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
    {
        var productImage = _mapper.Map<ProductImage>(createProductImageDto);
        await _productImageRepository.InsertOneAsync(productImage);
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
    {
        var productImage = _mapper.Map<ProductImage>(updateProductImageDto);
        await _productImageRepository.ReplaceOneAsync(x => x.ProductImageId == productImage.ProductImageId, productImage);
    }

    public async Task DeleteProductImageAsync(string productImageId)
    {
        await _productImageRepository.DeleteOneAsync(x => x.ProductImageId == productImageId);
    }

    public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
    {
        var productImages = await _productImageRepository.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductImageDto>>(productImages);
    }

    public async Task<GetByIdProductImageDto> GetProductImageByIdAsync(string productImageId)
    {
        var productImage = await _productImageRepository.Find(x => x.ProductImageId == productImageId).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductImageDto>(productImage);
    }
}