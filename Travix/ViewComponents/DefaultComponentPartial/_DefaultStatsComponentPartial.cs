using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travix.Dtos;
using WeatherDto = Travix.Dtos.WeatherDto;

namespace Travix.ViewComponents.DefaultComponentPartial;

public class _DefaultStatsComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultStatsComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        
        var weatherResponse = await client.GetAsync("http://localhost:5049/api/Stats/Weather");

        if (weatherResponse.IsSuccessStatusCode)
        {
            var weatherJson = await weatherResponse.Content.ReadAsStringAsync();
            var weather = JsonConvert.DeserializeObject<WeatherDto>(weatherJson);

            var kelvin = weather?.Main?.Temprature ?? 0;
            var tempC = Math.Round(kelvin - 273.15);

            ViewBag.Temp = tempC;
            ViewBag.Desc = weather?.Weather?[0]?.Description ?? "";
        }
        
        var usdResponse = await client.GetAsync("http://localhost:5049/api/Stats/Currency?from=usd&to=try");

        if (usdResponse.IsSuccessStatusCode)
        {
            var usdJson = await usdResponse.Content.ReadAsStringAsync();
            var currency = JsonConvert.DeserializeObject<CurrencyDto>(usdJson);

            ViewBag.UsdTry = currency.Result.ToString("F");
        }
        
        var eurResponse = await client.GetAsync("http://localhost:5049/api/Stats/Currency?from=eur&to=try");

        if (eurResponse.IsSuccessStatusCode)
        {
            var eurJson = await eurResponse.Content.ReadAsStringAsync();
            var currency = JsonConvert.DeserializeObject<CurrencyDto>(eurJson);

            ViewBag.EurTry = currency.Result.ToString("F");
        }
        return View();
    }
}