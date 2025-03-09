using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailsViewComponents;

public class _PartialProductDetailInformationComponent : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _baseUrl = "https://localhost:44359/api/ProductDetails";

    public _PartialProductDetailInformationComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string productId)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_baseUrl}/GetProductDetailByProductId/{productId}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var data = await responseMessage.Content.ReadAsStringAsync();
            var productDetail = JsonConvert.DeserializeObject<UpdateProductDetailDto>(data);
            return View(productDetail);
        }
        return View();
    }
}