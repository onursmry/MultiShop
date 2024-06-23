using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents;

public class _PartialAdminLayoutHeaderComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}