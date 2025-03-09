using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailsViewComponents;

public class _PartialProductDetailRecommendationsComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}