using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailsViewComponents;

public class _PartialProductInfoComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}