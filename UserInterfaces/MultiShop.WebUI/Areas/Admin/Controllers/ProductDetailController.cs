using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using System.Text;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/[controller]")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl = "https://localhost:44359/api/ProductDetails";

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("EditProductDetail/{productId}")]
        public async Task<IActionResult> EditProductDetail(string productId)
        {
            ViewBag.v0 = "Edit Product Detail";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Product Details";
            ViewBag.v3 = "Product Details Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_baseUrl}/GetProductDetailByProductId/{productId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var productDetail = JsonConvert.DeserializeObject<UpdateProductDetailDto>(data);
                return View(productDetail);
            }
            return View();
        }

        [HttpPost, Route("EditProductDetail/{id}")]
        public async Task<IActionResult> EditProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(updateProductDetailDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(_baseUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
