using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _PartialCategoriesComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}