using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Services.BrandServices;
using MultiShop.Catalog.Services.BrandServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var brands = await _brandService.GetAllBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(string id)
        {
            var brand = await _brandService.GetBrandByIdAsync(id);
            return Ok(brand);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandDto createBrandDto)
        {
            await _brandService.CreateBrandAsync(createBrandDto);
            return Ok("Brand Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandDto updateBrandDto)
        {
            await _brandService.UpdateBrandAsync(updateBrandDto);
            return Ok("Brand Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return Ok("Brand Deleted Successfully");
        }
    }
}
