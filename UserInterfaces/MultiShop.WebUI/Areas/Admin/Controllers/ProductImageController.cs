using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using System.Text;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl = "https://localhost:44359/api/ProductImages/";

        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet, Route("Index/{productId}")]
        public async Task<IActionResult> Index(string productId)
        {
            ViewBag.v0 = "Edit Product Images";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Product Images";
            ViewBag.v3 = "Product Image Operations";

            var client = _httpClientFactory.CreateClient();
            string endPoint = "ProductImagesByProductId?productId=";
            var responseMessage = await client.GetAsync($"{_baseUrl}{endPoint}{productId}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var productImages = JsonConvert.DeserializeObject<UpdateProductImageDto>(data);

                // Ensure the object and its Images list are initialized
                if (productImages == null)
                {
                    productImages = new UpdateProductImageDto
                    {
                        ProductId = productId,
                        Images = new List<string>()
                    };
                }
                else if (!productImages.Images.Any())
                {
                    productImages.Images = new List<string>();
                }

                return View(productImages);
            }

            return View(new UpdateProductImageDto
            {
                ProductId = productId,
                Images = new List<string>()
            });
        }


        [HttpPost, Route("Index/{productId}")]
        public async Task<IActionResult> Index(UpdateProductImageDto updateProductImageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(updateProductImageDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(_baseUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
