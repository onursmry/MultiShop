using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index(string categoryId)
        {
            ViewBag.CategoryId = categoryId;
            return View();
        }

        public IActionResult ProductDetail(string productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }
    }
}
