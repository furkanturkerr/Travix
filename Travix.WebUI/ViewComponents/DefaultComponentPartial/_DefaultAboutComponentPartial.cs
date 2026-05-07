using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travix.Dtos.AdminDtos.AboutDtos;
using Travix.Dtos.AdminDtos.HeroDtos;

namespace Travix.ViewComponents.DefaultComponentPartial;

public class _DefaultAboutComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultAboutComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
    
        var response = await client.GetAsync("http://localhost:5049/api/Abouts/AboutsTrue");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
            return View(value ?? new List<ResultAboutDto>());
        }
    
        return View(new List<ResultAboutDto>());
    }
}