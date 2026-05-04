using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Travix.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public HotelsController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetHotels(string city, string checkIn, string checkOut, int? adults, string? currency, string? language, int? minPrice, int? maxPrice, string? room)
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={city}"),
                Headers =
                {
                    { "x-rapidapi-key", _configuration["ApiKey:rapidapi"] },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };
            string destId = "";
            
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var destBody = await response.Content.ReadAsStringAsync();
                dynamic destData = JsonConvert.DeserializeObject(destBody);
                destId = destData?.data?[0]?.dest_id;
            }

            adults = adults is null || adults < 1 ? 1 : adults;
            room = string.IsNullOrWhiteSpace(room) ? "1" : room;
            currency = string.IsNullOrWhiteSpace(currency) ? "AED" : currency;
            language = string.IsNullOrWhiteSpace(language) ? "en-us" : language;
            
            var priceParams = (minPrice > 0 || maxPrice > 0)
                ? $"&price_min={minPrice}&price_max={maxPrice}"
                : "";
            
            var hotelRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id={destId}&search_type=CITY&arrival_date={checkIn}&departure_date={checkOut}&adults={adults}&children_age=0%2C17&room_qty={room}&page_number=1{priceParams}&units=metric&temperature_unit=c&languagecode={language}&currency_code={currency}"),
                Headers =
                {
                    { "x-rapidapi-key", _configuration["ApiKey:rapidapi"] },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };
            using (var hotelResponse = await client.SendAsync(hotelRequest))
            {
                hotelResponse.EnsureSuccessStatusCode();
                var body = await hotelResponse.Content.ReadAsStringAsync();
                return Ok(body);
            }
            
        }

        [HttpGet("GetHotelDetails")]
        public async Task<IActionResult> GetHotelDetails(int id, string checkIn, string checkOut)
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/getHotelDetails?hotel_id={id}&arrival_date={checkIn}&departure_date={checkOut}&adults=1&children_age=1%2C17&room_qty=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=EUR"),
                Headers =
                {
                    { "x-rapidapi-key", _configuration["ApiKey:rapidapi"] },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return Ok(body);
            }
        }
        
        
    }
}
