using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _PartialSpecialOfferComponent : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _baseUrl = "https://localhost:44359/api/SpecialOffer";

    public _PartialSpecialOfferComponent(IHttpClientFactory httpClientFactory)
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
            var specialOffers = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(data);
            return View(specialOffers);
        }
        return View();
    }
}