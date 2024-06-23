using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents;

public class _UILayoutPartialTopBarComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}