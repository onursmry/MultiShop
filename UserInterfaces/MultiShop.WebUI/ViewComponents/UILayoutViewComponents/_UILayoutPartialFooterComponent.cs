using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents;

public class _UILayoutPartialFooterComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}