using MultiShop.Catalog.Dtos.DiscountOfferDtos;

namespace MultiShop.Catalog.Services.DiscountOfferServices;

public interface IDiscountOfferService
{
    Task<List<ResultDiscountOfferDto>> GetAllDiscountOffersAsync();
    Task<GetByIdDiscountOfferDto> GetDiscountOfferByIdAsync(string discountOfferId);
    Task CreateDiscountOfferAsync(CreateDiscountOfferDto createDiscountOfferDto);
    Task UpdateDiscountOfferAsync(UpdateDiscountOfferDto updateDiscountOfferDto);
    Task DeleteDiscountOfferAsync(string discountOfferId);
}