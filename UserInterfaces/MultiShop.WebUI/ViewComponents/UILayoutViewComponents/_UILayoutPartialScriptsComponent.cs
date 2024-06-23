using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents;

public class _UILayoutPartialScriptsComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}