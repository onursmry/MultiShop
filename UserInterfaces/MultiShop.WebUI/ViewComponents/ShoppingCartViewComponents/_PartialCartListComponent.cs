using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents;

public class _PartialCartListComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}