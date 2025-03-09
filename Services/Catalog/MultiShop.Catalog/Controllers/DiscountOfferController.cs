using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.DiscountOfferDtos;
using MultiShop.Catalog.Services.DiscountOfferServices;
using MultiShop.Catalog.Services.DiscountOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountOfferController : ControllerBase
    {
        private readonly IDiscountOfferService _discountOfferService;

        public DiscountOfferController(IDiscountOfferService discountOfferService)
        {
            _discountOfferService = discountOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountOfferList()
        {
            var discountOffers = await _discountOfferService.GetAllDiscountOffersAsync();
            return Ok(discountOffers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountOfferById(string id)
        {
            var DiscountOffer = await _discountOfferService.GetDiscountOfferByIdAsync(id);
            return Ok(DiscountOffer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountOffer([FromBody] CreateDiscountOfferDto createDiscountOfferDto)
        {
            await _discountOfferService.CreateDiscountOfferAsync(createDiscountOfferDto);
            return Ok("Discount Offer Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountOffer([FromBody] UpdateDiscountOfferDto updateDiscountOfferDto)
        {
            await _discountOfferService.UpdateDiscountOfferAsync(updateDiscountOfferDto);
            return Ok("Discount Offer Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscountOffer(string id)
        {
            await _discountOfferService.DeleteDiscountOfferAsync(id);
            return Ok("Discount Offer Deleted Successfully");
        }
    }
}
