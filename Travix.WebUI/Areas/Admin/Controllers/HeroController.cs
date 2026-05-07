using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travix.Dtos.AdminDtos.HeroDtos;

namespace Travix.Areas.Admin.Controllers;
[Area("Admin")]

public class HeroController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HeroController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
    
        var response = await client.GetAsync("http://localhost:5049/api/Heroes");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultHeroDto>>(jsonData);
            return View(value ?? new List<ResultHeroDto>());
        }
    
        return View(new List<ResultHeroDto>());
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateHeroDto Hero)
    {
        var client = _httpClientFactory.CreateClient();
        
        var json = JsonConvert.SerializeObject(Hero);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5049/api/Heroes", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(Hero);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("http://localhost:5049/api/Heroes/" + id);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateHeroDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateHeroDto HeroDto)
    {
        var client = _httpClientFactory.CreateClient();

        var json = JsonConvert.SerializeObject(HeroDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5049/api/Heroes", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(HeroDto);   
    }

    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        await client.DeleteAsync("http://localhost:5049/api/Heroes?id=" + id);
        return RedirectToAction("Index");
    }
}