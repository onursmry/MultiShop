using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents;

public class _PartialCartCouponCodeComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}