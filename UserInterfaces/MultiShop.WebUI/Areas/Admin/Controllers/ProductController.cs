using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl = "https://localhost:44359/api/Products";
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Product Operations";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Products";
            ViewBag.v3 = "Products List";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_baseUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ProductResultDto>>(data);
                return View(categories);
            }

            return View();
        }

        [Route("IndexCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ViewBag.v0 = "Product Operations";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Products";
            ViewBag.v3 = "Products List";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_baseUrl}/GetAllProductsWithCategory");

            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ProductResultWithCategoryDto>>(data);
                return View(categories);
            }

            return View();
        }

        [HttpGet, Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v0 = "Create New Product";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Products";
            ViewBag.v3 = "Product Operations";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44359/api/Categories");

            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<CategoryResultDto>>(data);
                List<SelectListItem> categoryList = (from category in categories
                                                     select new SelectListItem
                                                     {
                                                         Text = category.CategoryName,
                                                         Value = category.CategoryId
                                                     }).ToList();
                ViewBag.CategoriesList = categoryList;
            }

            return View();
        }

        [HttpPost, Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductCreateDto productCreateDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(productCreateDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(_baseUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet, Route("EditProduct/{id}")]
        public async Task<IActionResult> EditProduct(string id)
        {
            ViewBag.v0 = "Edit Product";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Products";
            ViewBag.v3 = "Product Operations";

            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44359/api/Categories");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<CategoryResultDto>>(jsonData1);
            List<SelectListItem> categoryList = (from category in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = category.CategoryName,
                                                     Value = category.CategoryId
                                                 }).ToList();
            ViewBag.CategoriesList = categoryList;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_baseUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductUpdateDto>(data);
                return View(product);
            }

            return View();
        }

        [HttpPost, Route("EditProduct/{id}")]
        public async Task<IActionResult> EditProduct(ProductUpdateDto productUpdateDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(productUpdateDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_baseUrl}/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{_baseUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
