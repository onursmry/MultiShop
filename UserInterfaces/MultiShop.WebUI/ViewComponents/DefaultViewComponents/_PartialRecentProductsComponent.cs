using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _PartialRecentProductsComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}