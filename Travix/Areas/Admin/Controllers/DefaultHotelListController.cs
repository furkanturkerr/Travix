using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Travix.Dtos;

namespace Travix.Areas.Admin.Controllers;

[Area("Admin")]
public class DefaultHotelListController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DefaultHotelListController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("http://localhost:5049/api/DefaultHotelList/HomeHotelSetting");

        if (!response.IsSuccessStatusCode)
        {
            return View(new DefaultHotelListDto
            {
                homeHotelCity = "milano",
                homeHotelCurrency = "EUR",
                homeHotelLanguage = "en-us",
                homeHotelAdults = 2,
                homeHotelRoom = "1"
            });
        }

        var json = await response.Content.ReadAsStringAsync();
        var value = JsonConvert.DeserializeObject<DefaultHotelListDto>(json);

        return View(value);
    }

    [HttpPost]
    public async Task<IActionResult> Index(DefaultHotelListDto siteSettingDto)
    {
        var client = _httpClientFactory.CreateClient();

        var json = JsonConvert.SerializeObject(siteSettingDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PutAsync(
            "http://localhost:5049/api/DefaultHotelList/UpdateHomeHotelSetting",
            content
        );

        if (response.IsSuccessStatusCode)
        {
            TempData["Success"] = "Anasayfa otel ayarları güncellendi.";
        }
        else
        {
            TempData["Error"] = "Ayarlar güncellenirken hata oluştu.";
        }

        return RedirectToAction("Index");
    }
}