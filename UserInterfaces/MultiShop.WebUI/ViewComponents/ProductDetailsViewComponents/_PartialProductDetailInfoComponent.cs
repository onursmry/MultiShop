using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailsViewComponents;

public class _PartialProductDetailInfoComponent : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _baseUrl = "https://localhost:44359/api/Products";
    public _PartialProductDetailInfoComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string productId)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_baseUrl}/{productId}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var data = await responseMessage.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductResultWithCategoryDto>(data);
            return View(product);
        }

        return View();
    }
}