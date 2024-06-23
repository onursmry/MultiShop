using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMongoCollection<Category> _categoryCollection;

    public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        var product = _mapper.Map<Product>(createProductDto);
        await _productCollection.InsertOneAsync(product);
    }

    public async Task DeleteProductAsync(string productId)
    {
        await _productCollection.DeleteOneAsync(x => x.ProductId == productId);
    }

    public async Task<List<ResultProductsWithCategoryDto>> GetAllProductsWithCategoryAsync()
    {
        var products = await _productCollection.Find(x => true).ToListAsync();
        foreach (var product in products)
        {
            product.Category = await _categoryCollection.Find(x => x.CategoryId == product.CategoryId).FirstOrDefaultAsync();
        }
        return _mapper.Map<List<ResultProductsWithCategoryDto>>(products);
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var product = _mapper.Map<Product>(updateProductDto);
        await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, product);
    }

    public async Task<List<ResultProductDto>> GetAllProductsAsync()
    {
        var products = await _productCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDto>>(products);
    }

    public async Task<GetByIdProductDto> GetProductByIdAsync(string productId)
    {
        var product = await _productCollection.Find(x => x.ProductId == productId).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDto>(product);
    }
}