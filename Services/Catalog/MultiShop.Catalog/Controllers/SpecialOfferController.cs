using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOfferController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> SpecialOfferList()
        {
            var categories = await _specialOfferService.GetAllSpecialOffersAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var specialOffer = await _specialOfferService.GetSpecialOfferByIdAsync(id);
            return Ok(specialOffer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer([FromBody] CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok("Special Offer Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer([FromBody] UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok("Special Offer Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("Special Offer Deleted Successfully");
        }
    }
}
