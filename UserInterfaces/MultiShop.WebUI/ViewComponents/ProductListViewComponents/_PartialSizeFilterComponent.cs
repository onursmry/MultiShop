﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents;

public class _PartialSizeFilterComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}