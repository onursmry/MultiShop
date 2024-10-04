using MultiShop.Catalog.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.Services.SpecialOfferServices;

public interface ISpecialOfferService
{
    Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync();
    Task<GetSpecialOfferByIdDto> GetSpecialOfferByIdAsync(string specialOfferId);
    Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
    Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
    Task DeleteSpecialOfferAsync(string specialOfferId);
}