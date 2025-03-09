using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.ReviewDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class ReviewController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl = "https://localhost:7241/api/Review";

        public ReviewController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Review Operations";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Reviews";
            ViewBag.v3 = "Reviews List";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_baseUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var reviews = JsonConvert.DeserializeObject<List<ResultReviewDto>>(data);
                return View(reviews);
            }

            return View();
        }

        [HttpGet, Route("EditReview/{id}")]
        public async Task<IActionResult> EditReview(string id)
        {
            ViewBag.v0 = "Review Operations";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Reviews";
            ViewBag.v3 = "Reviews List";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_baseUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var review = JsonConvert.DeserializeObject<UpdateReviewDto>(data);
                return View(review);
            }
            return View();
        }

        [HttpPost, Route("EditReview/{id}")]
        public async Task<IActionResult> EditReview(UpdateReviewDto updateReviewDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(updateReviewDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(_baseUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Review", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteReview/{id}")]
        public async Task<IActionResult> DeleteReview(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{_baseUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Review", new { area = "Admin" });
            }
            return View();
        }
    }
}
