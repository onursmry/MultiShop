using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialOfferServices;

public class SpecialOfferService : ISpecialOfferService
{
    private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;
    private readonly IMapper _mapper;

    public SpecialOfferService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _specialOfferCollection = database.GetCollection<SpecialOffer>(databaseSettings.SpecialOfferCollectionName);
        _mapper = mapper;
    }

    public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
    {
        var specialOffer = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
        await _specialOfferCollection.InsertOneAsync(specialOffer);
    }

    public async Task DeleteSpecialOfferAsync(string specialOfferId)
    {
        await _specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId == specialOfferId);
    }

    public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        var specialOffer = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
        await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId == updateSpecialOfferDto.SpecialOfferId, specialOffer);
    }

    public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync()
    {
        var specialOffers = await _specialOfferCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultSpecialOfferDto>>(specialOffers);
    }

    public async Task<GetSpecialOfferByIdDto> GetSpecialOfferByIdAsync(string specialOfferId)
    {
        var specialOffer = await _specialOfferCollection.Find(x => x.SpecialOfferId == specialOfferId).FirstOrDefaultAsync();
        return _mapper.Map<GetSpecialOfferByIdDto>(specialOffer);
    }
}