using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents;

public class _PartialProductSortingComponent:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}