using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _PartialFeaturedProductsComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}