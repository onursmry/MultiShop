using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl = "https://localhost:44359/api/Brand";

        public BrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Brand Operations";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Brands";
            ViewBag.v3 = "Brands List";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_baseUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var brands = JsonConvert.DeserializeObject<List<ResultBrandDto>>(data);
                return View(brands);
            }

            return View();
        }

        [HttpGet, Route("CreateBrand")]
        public IActionResult CreateBrand()
        {
            ViewBag.v0 = "Create New Brand";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Brands";
            ViewBag.v3 = "Brands Operations";
            return View();
        }

        [HttpPost, Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(createBrandDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(_baseUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet, Route("EditBrand/{id}")]
        public async Task<IActionResult> EditBrand(string id)
        {
            ViewBag.v0 = "Edit Brand";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Brands";
            ViewBag.v3 = "Brands Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_baseUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var brand = JsonConvert.DeserializeObject<UpdateBrandDto>(data);
                return View(brand);
            }
            return View();
        }

        [HttpPost, Route("EditBrand/{id}")]
        public async Task<IActionResult> EditBrand(UpdateBrandDto updateBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(updateBrandDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(_baseUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{_baseUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }
    }
}
