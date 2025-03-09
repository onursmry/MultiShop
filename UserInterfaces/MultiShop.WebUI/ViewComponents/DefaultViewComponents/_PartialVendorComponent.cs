using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _PartialVendorComponent : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _baseUrl = "https://localhost:44359/api/Brand";

    public _PartialVendorComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(_baseUrl);

        if (responseMessage.IsSuccessStatusCode)
        {
            var data = await responseMessage.Content.ReadAsStringAsync();
            var brands = JsonConvert.DeserializeObject<List<ResultBrandDto>>(data);
            return View(brands);
        }
        return View();
    }
}