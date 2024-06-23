using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _PartialVendorComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}