using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents;

public class _PartialPriceFilterComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}