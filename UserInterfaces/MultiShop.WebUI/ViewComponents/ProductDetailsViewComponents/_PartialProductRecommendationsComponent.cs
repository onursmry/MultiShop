using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailsViewComponents;

public class _PartialProductRecommendationsComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}