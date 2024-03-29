using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        var category = _mapper.Map<Category>(createCategoryDto);
        await _categoryCollection.InsertOneAsync(category);
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultCategoryDto>>(categories);
    }

    public async Task<GetByIdCategoryDto> GetCategoryByIdAsync(string categoryId)
    {
        var category = await _categoryCollection.Find(x => x.CategoryId == categoryId).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdCategoryDto>(category);
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        var category = _mapper.Map<Category>(updateCategoryDto);
        await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, category);
    }

    public async Task DeleteCategoryAsync(string categoryId)
    {
        await _categoryCollection.DeleteOneAsync(x => x.CategoryId == categoryId);
    }
}