using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl = "https://localhost:44359/api/About";

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "About Operations";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Abouts";
            ViewBag.v3 = "About List";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_baseUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var abouts = JsonConvert.DeserializeObject<List<ResultAboutDto>>(data);
                return View(abouts);
            }

            return View();
        }

        [HttpGet, Route("CreateAbout")]
        public IActionResult CreateAbout()
        {
            ViewBag.v0 = "Create New About";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Abouts";
            ViewBag.v3 = "About Operations";
            return View();
        }

        [HttpPost, Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(createAboutDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(_baseUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet, Route("EditAbout/{id}")]
        public async Task<IActionResult> EditAbout(string id)
        {
            ViewBag.v0 = "Edit About";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Abouts";
            ViewBag.v3 = "About Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_baseUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var About = JsonConvert.DeserializeObject<UpdateAboutDto>(data);
                return View(About);
            }
            return View();
        }

        [HttpPost, Route("EditAbout/{id}")]
        public async Task<IActionResult> EditAbout(UpdateAboutDto updateAboutDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(updateAboutDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(_baseUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{_baseUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }
    }
}
