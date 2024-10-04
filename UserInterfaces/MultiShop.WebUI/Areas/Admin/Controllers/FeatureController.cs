using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl = "https://localhost:44359/api/Feature";

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Feature Operations";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Features";
            ViewBag.v3 = "Features List";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_baseUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var features = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(data);
                return View(features);
            }

            return View();
        }

        [HttpGet, Route("CreateFeature")]
        public IActionResult CreateFeature()
        {
            ViewBag.v0 = "Create New Feature";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Features";
            ViewBag.v3 = "Features Operations";
            return View();
        }

        [HttpPost, Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(createFeatureDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(_baseUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet, Route("EditFeature/{id}")]
        public async Task<IActionResult> EditFeature(string id)
        {
            ViewBag.v0 = "Edit Feature";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Features";
            ViewBag.v3 = "Features Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_baseUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var feature = JsonConvert.DeserializeObject<UpdateFeatureDto>(data);
                return View(feature);
            }
            return View();
        }

        [HttpPost, Route("EditFeature/{id}")]
        public async Task<IActionResult> EditFeature(UpdateFeatureDto updateFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(updateFeatureDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(_baseUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{_baseUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }
    }
}
