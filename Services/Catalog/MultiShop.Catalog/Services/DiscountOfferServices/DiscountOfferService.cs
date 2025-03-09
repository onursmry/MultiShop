using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.DiscountOfferDtos;
using MultiShop.Catalog.Dtos.DiscountOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.DiscountOfferServices;

public class DiscountOfferService : IDiscountOfferService
{
    private readonly IMongoCollection<DiscountOffer> _discountOfferCollection;
    private readonly IMapper _mapper;

    public DiscountOfferService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _discountOfferCollection = database.GetCollection<DiscountOffer>(databaseSettings.DiscountOfferCollectionName);
        _mapper = mapper;
    }

    public async Task CreateDiscountOfferAsync(CreateDiscountOfferDto createDiscountOfferDto)
    {
        var discountOffer = _mapper.Map<DiscountOffer>(createDiscountOfferDto);
        await _discountOfferCollection.InsertOneAsync(discountOffer);
    }

    public async Task<List<ResultDiscountOfferDto>> GetAllDiscountOffersAsync()
    {
        var discountOffers = await _discountOfferCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultDiscountOfferDto>>(discountOffers);
    }

    public async Task<GetByIdDiscountOfferDto> GetDiscountOfferByIdAsync(string discountOfferId)
    {
        var discountOffer = await _discountOfferCollection.Find(x => x.DiscountOfferId == discountOfferId).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdDiscountOfferDto>(discountOffer);
    }

    public async Task UpdateDiscountOfferAsync(UpdateDiscountOfferDto updateDiscountOfferDto)
    {
        var discountOffer = _mapper.Map<DiscountOffer>(updateDiscountOfferDto);
        await _discountOfferCollection.FindOneAndReplaceAsync(x => x.DiscountOfferId == updateDiscountOfferDto.DiscountOfferId, discountOffer);
    }

    public async Task DeleteDiscountOfferAsync(string discountOfferId)
    {
        await _discountOfferCollection.DeleteOneAsync(x => x.DiscountOfferId == discountOfferId);
    }
}