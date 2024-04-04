using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<ProductDetail> _productDetailRepository;

    public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productDetailRepository = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
    {
        var productDetail = _mapper.Map<ProductDetail>(createProductDetailDto);
        await _productDetailRepository.InsertOneAsync(productDetail);
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        var productDetail = _mapper.Map<ProductDetail>(updateProductDetailDto);
        await _productDetailRepository.ReplaceOneAsync(x => x.ProductDetailId == productDetail.ProductDetailId, productDetail);
    }

    public async Task DeleteProductDetailAsync(string productDetailId)
    {
        await _productDetailRepository.DeleteOneAsync(x => x.ProductDetailId == productDetailId);
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync()
    {
        var productDetails = await _productDetailRepository.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDetailDto>>(productDetails);
    }

    public async Task<GetByIdProductDetailDto> GetProductDetailByIdAsync(string productDetailId)
    {
        var productDetail = await _productDetailRepository.Find(x => x.ProductDetailId == productDetailId).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDetailDto>(productDetail);
    }
}