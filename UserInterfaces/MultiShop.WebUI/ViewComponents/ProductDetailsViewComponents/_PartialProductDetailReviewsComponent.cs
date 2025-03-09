using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.ReviewDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailsViewComponents;

public class _PartialProductDetailReviewsComponent : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _baseUrl = "https://localhost:7241/api/Review";

    public _PartialProductDetailReviewsComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string productId)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_baseUrl}/ReviewListByProductId/{productId}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var data = await responseMessage.Content.ReadAsStringAsync();
            var reviews = JsonConvert.DeserializeObject<List<ResultReviewDto>>(data);
            return View(reviews);
        }

        return View();
    }
}