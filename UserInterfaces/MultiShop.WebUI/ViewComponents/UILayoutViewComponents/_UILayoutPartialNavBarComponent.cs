using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents;

public class _UILayoutPartialNavBarComponent:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}