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
    

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();

        var city = "milano";
        var checkIn = "2026-05-06";
        var checkOut = "2026-05-08";
        var adults = 2;
        var currency = "EUR";
        var language = "en-us";
        var room = "1";

        var response = await client.GetAsync(
            $"http://localhost:5049/api/Hotels?city={city}&checkIn={checkIn}&checkOut={checkOut}&adults={adults}&currency={currency}&language={language}&room={room}"
        );

        if (!response.IsSuccessStatusCode)
            return View("List", new List<Hotel>());

        var json = await response.Content.ReadAsStringAsync();
        var jsonData = JsonConvert.DeserializeObject<HotelListDto>(json);

        var hotels = jsonData?.data?.hotels ?? new List<Hotel>();

        return View(hotels);
    }

    
    

    [HttpPost]
    public async Task<IActionResult> List(string city, string checkIn, string checkOut, int? adults, string? currency, string? language, int? minPrice, int? maxPrice, string? room)
    {
        var client = _httpClientFactory.CreateClient();
        
        ViewBag.City = city;
        ViewBag.CheckIn = checkIn;
        ViewBag.CheckOut = checkOut;
        ViewBag.Adults = adults;
        ViewBag.Currency = currency;
        ViewBag.Language = language;
        ViewBag.MinPrice = minPrice;
        ViewBag.MaxPrice = maxPrice;
        ViewBag.Room = room;
        
        var response = await client.GetAsync(
            $"http://localhost:5049/api/Hotels?city={city}&checkIn={checkIn}&checkOut={checkOut}&adults={adults}&currency={currency}&language={language}&minPrice={minPrice}&maxPrice={maxPrice}&room={room}"
        );

        if (!response.IsSuccessStatusCode)
            return View(new List<Hotel>());

        var json = await response.Content.ReadAsStringAsync();
        var jsonData = JsonConvert.DeserializeObject<HotelListDto>(json);

        var hotels = jsonData?.data?.hotels ?? new List<Hotel>();

        return View(hotels);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id, string checkIn, string checkOut)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync(
            $"http://localhost:5049/api/Hotels/GetHotelDetails?id={id}&checkIn={checkIn}&checkOut={checkOut}"
        );

        if (!response.IsSuccessStatusCode)
            return View();

        var json = await response.Content.ReadAsStringAsync();
        var jsonData = JsonConvert.DeserializeObject<HotelDetailDto>(json);

        return View(jsonData);
    }
}