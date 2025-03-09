using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.DiscountOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _PartialDiscountOfferComponent : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _baseUrl = "https://localhost:44359/api/DiscountOffer";

    public _PartialDiscountOfferComponent(IHttpClientFactory httpClientFactory)
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
            var discountOffers = JsonConvert.DeserializeObject<List<ResultDiscountOfferDto>>(data);
            return View(discountOffers);
        }
        return View();
    }
}