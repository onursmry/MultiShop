using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl = "https://localhost:44359/api/FeatureSliders";

        public FeatureSliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Feature Slider Operations";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Feature Sliders";
            ViewBag.v3 = "Feature Slider List";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_baseUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var featureSliders = JsonConvert.DeserializeObject<List<FeatureSliderResultDto>>(data);
                return View(featureSliders);
            }

            return View();
        }

        [HttpGet, Route("CreateFeatureSlider")]
        public IActionResult CreateFeatureSlider()
        {
            ViewBag.v0 = "Create New FeatureSlider";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "FeatureSliders";
            ViewBag.v3 = "FeatureSlider Operations";
            return View();
        }

        [HttpPost, Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(FeatureSliderCreateDto featureSliderCreateDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(featureSliderCreateDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(_baseUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet, Route("EditFeatureSlider/{id}")]
        public async Task<IActionResult> EditFeatureSlider(string id)
        {
            ViewBag.v0 = "Edit FeatureSlider";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "FeatureSliders";
            ViewBag.v3 = "FeatureSlider Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_baseUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var FeatureSlider = JsonConvert.DeserializeObject<FeatureSliderUpdateDto>(data);
                return View(FeatureSlider);
            }
            return View();
        }

        [HttpPost, Route("EditFeatureSlider/{id}")]
        public async Task<IActionResult> EditFeatureSlider(FeatureSliderUpdateDto featureSliderUpdateDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(featureSliderUpdateDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(_baseUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{_baseUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }
    }
}
