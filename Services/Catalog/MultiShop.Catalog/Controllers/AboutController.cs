using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Services.AboutServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var categories = await _aboutService.GetAllAboutsAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(string id)
        {
            var About = await _aboutService.GetAboutByIdAsync(id);
            return Ok(About);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout([FromBody] CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return Ok("About Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout([FromBody] UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return Ok("About Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return Ok("About Deleted Successfully");
        }
    }
}
