using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travix.Dtos;
namespace Travix.Controllers;

public class HotelController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HotelController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpPost]
    public async Task<IActionResult> List(string city, string checkIn, string checkOut, int adults, string currency, string language, int minPrice, int maxPrice, string room)
    {
        var client = _httpClientFactory.CreateClient();
        
        var response = await client.GetAsync($"http://localhost:5049/api/Hotels?city={city}&checkIn={checkIn}&checkOut={checkOut}&adults={adults}&currency={currency}&language={language}&minPrice={minPrice}&maxPrice={maxPrice}&room={room}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<HotelListDto>(json);

            var hotels = jsonData.data.hotels;

            return View(hotels);
        }
        
        return View();
    }
}