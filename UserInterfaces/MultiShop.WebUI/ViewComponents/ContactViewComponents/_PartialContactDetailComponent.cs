﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ContactViewComponents;

public class _PartialContactDetailComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}