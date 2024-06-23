using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailsViewComponents;

public class _PartialProductDescriptionComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}