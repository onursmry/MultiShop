using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _PartialFeatureComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}