using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travix.Dtos;

namespace Travix.ViewComponents.DefaultComponentPartial;

public class _DefaultHotelComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultHotelComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();

        var settingResponse = await client.GetAsync("http://localhost:5049/api/SiteSettings/HomeHotelSetting");

        var setting = new DefaultHotelListDto
        {
            homeHotelCity = "milano",
            homeHotelCurrency = "EUR",
            homeHotelLanguage = "en-us",
            homeHotelAdults = 2,
            homeHotelRoom = "1"
        };

        if (settingResponse.IsSuccessStatusCode)
        {
            var settingJson = await settingResponse.Content.ReadAsStringAsync();
            setting = JsonConvert.DeserializeObject<DefaultHotelListDto>(settingJson);
        }

        var checkIn = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
        var checkOut = DateTime.Now.AddDays(10).ToString("yyyy-MM-dd");

        var hotelResponse = await client.GetAsync(
            $"http://localhost:5049/api/Hotels?city={setting.homeHotelCity}&checkIn={checkIn}&checkOut={checkOut}&adults={setting.homeHotelAdults}&currency={setting.homeHotelCurrency}&language={setting.homeHotelLanguage}&room={setting.homeHotelRoom}"
        );

        var hotels = new List<Hotel>();

        if (hotelResponse.IsSuccessStatusCode)
        {
            var hotelJson = await hotelResponse.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<HotelListDto>(hotelJson);

            hotels = jsonData?.data?.hotels ?? new List<Hotel>();
        }

        return View(hotels);
    }
}