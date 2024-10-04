using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl = "https://localhost:44359/api/SpecialOffer";

        public SpecialOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Special Offer Operations";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Special Offers";
            ViewBag.v3 = "Special Offer List";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_baseUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var specialOffers = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(data);
                return View(specialOffers);
            }

            return View();
        }

        [HttpGet, Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
            ViewBag.v0 = "Create New Special Offer";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Special Offers";
            ViewBag.v3 = "Special Offer Operations";
            return View();
        }

        [HttpPost, Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(createSpecialOfferDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(_baseUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet, Route("EditSpecialOffer/{id}")]
        public async Task<IActionResult> EditSpecialOffer(string id)
        {
            ViewBag.v0 = "Edit SpecialOffer";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Special Offers";
            ViewBag.v3 = "Special Offer Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_baseUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var specialOffer = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(data);
                return View(specialOffer);
            }
            return View();
        }

        [HttpPost, Route("EditSpecialOffer/{id}")]
        public async Task<IActionResult> EditSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(updateSpecialOfferDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(_baseUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{_baseUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            return View();
        }
    }
}
