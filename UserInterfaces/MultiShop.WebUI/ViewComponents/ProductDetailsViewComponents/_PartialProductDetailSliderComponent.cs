using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailsViewComponents;

public class _PartialProductDetailSliderComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}