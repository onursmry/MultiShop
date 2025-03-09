using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.DiscountOfferDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class DiscountOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl = "https://localhost:44359/api/DiscountOffer";

        public DiscountOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Discount Offer Operations";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Discount Offers";
            ViewBag.v3 = "Discount Offers List";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_baseUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var discountOffers = JsonConvert.DeserializeObject<List<ResultDiscountOfferDto>>(data);
                return View(discountOffers);
            }

            return View();
        }

        [HttpGet, Route("CreateDiscountOffer")]
        public IActionResult CreateDiscountOffer()
        {
            ViewBag.v0 = "Create New Discount Offer";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Discount Offers";
            ViewBag.v3 = "Discount Offer Operations";
            return View();
        }

        [HttpPost, Route("CreateDiscountOffer")]
        public async Task<IActionResult> CreateDiscountOffer(CreateDiscountOfferDto createDiscountOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(createDiscountOfferDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(_baseUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "DiscountOffer", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet, Route("EditDiscountOffer/{id}")]
        public async Task<IActionResult> EditDiscountOffer(string id)
        {
            ViewBag.v0 = "Edit Discount Offer";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Discount Offers";
            ViewBag.v3 = "Discount Offer Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_baseUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var discountOffer = JsonConvert.DeserializeObject<UpdateDiscountOfferDto>(data);
                return View(discountOffer);
            }
            return View();
        }

        [HttpPost, Route("EditDiscountOffer/{id}")]
        public async Task<IActionResult> EditDiscountOffer(UpdateDiscountOfferDto updateDiscountOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(updateDiscountOfferDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(_baseUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "DiscountOffer", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteDiscountOffer/{id}")]
        public async Task<IActionResult> DeleteDiscountOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{_baseUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "DiscountOffer", new { area = "Admin" });
            }
            return View();
        }
    }
}
