using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _PartialDiscountOfferComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}