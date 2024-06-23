using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _DefaultPartialCarouselComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}