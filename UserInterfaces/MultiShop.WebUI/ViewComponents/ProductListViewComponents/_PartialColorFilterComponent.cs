﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents;

public class _PartialColorFilterComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}