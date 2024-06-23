using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailsViewComponents;

public class _PartialProductReviewsComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}