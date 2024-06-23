using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _PartialSpecialOfferComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}