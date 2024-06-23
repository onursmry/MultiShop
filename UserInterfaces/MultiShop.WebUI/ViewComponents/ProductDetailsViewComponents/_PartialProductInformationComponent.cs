using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailsViewComponents;

public class _PartialProductInformationComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}