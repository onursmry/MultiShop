using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents;

public class _PartialCartCheckoutComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}