using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ContactViewComponents;

public class _PartialContactMessageComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}