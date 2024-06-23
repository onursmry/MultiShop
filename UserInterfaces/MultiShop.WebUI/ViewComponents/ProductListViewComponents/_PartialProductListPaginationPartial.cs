using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents;

public class _PartialProductListPaginationPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}