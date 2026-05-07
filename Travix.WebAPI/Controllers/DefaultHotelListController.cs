using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.Entites;

namespace Travix.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DefaultHotelListController : ControllerBase
{
    private readonly TravixContext _context;

    public DefaultHotelListController(TravixContext context)
    {
        _context = context;
    }

    [HttpGet("HomeHotelSetting")]
    public IActionResult HomeHotelSetting()
    {
        var value = _context.HotelLists.FirstOrDefault();

        if (value == null)
        {
            value = new HotelList
            {
                HomeHotelCity = "milano",
                HomeHotelCurrency = "EUR",
                HomeHotelLanguage = "en-us",
                HomeHotelAdults = 2,
                HomeHotelRoom = "1"
            };

            _context.HotelLists.Add(value);
            _context.SaveChanges();
        }

        return Ok(value);
    }

    [HttpPut("UpdateHomeHotelSetting")]
    public IActionResult UpdateHomeHotelSetting(HotelList siteSetting)
    {
        var value = _context.HotelLists.FirstOrDefault();

        if (value == null)
        {
            _context.HotelLists.Add(siteSetting);
        }
        else
        {
            value.HomeHotelCity = siteSetting.HomeHotelCity;
            value.HomeHotelCurrency = siteSetting.HomeHotelCurrency;
            value.HomeHotelLanguage = siteSetting.HomeHotelLanguage;
            value.HomeHotelAdults = siteSetting.HomeHotelAdults;
            value.HomeHotelRoom = siteSetting.HomeHotelRoom;
        }

        _context.SaveChanges();

        return Ok("Anasayfa otel ayarları güncellendi.");
    }
}