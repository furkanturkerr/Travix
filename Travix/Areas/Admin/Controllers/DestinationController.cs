using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travix.Dtos.AdminDtos.DestinationDtos;

namespace Travix.Areas.Admin.Controllers;
[Area("Admin")]

public class DestinationController : Controller
{
   private readonly IHttpClientFactory _httpClientFactory;

    public DestinationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        
        var response = await client.GetAsync("http://localhost:5049/api/Destinations");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultDestinationDto>>(jsonData);
            return View(value);
        }
        
        return View();
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDestinationDto Destination)
    {
        var client = _httpClientFactory.CreateClient();
        
        var json = JsonConvert.SerializeObject(Destination);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5049/api/Destinations", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(Destination);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("http://localhost:5049/api/Destinations/" + id);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateDestinationDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateDestinationDto DestinationDto)
    {
        var client = _httpClientFactory.CreateClient();

        var json = JsonConvert.SerializeObject(DestinationDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5049/api/Destinations", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(DestinationDto);   
    }

    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        await client.DeleteAsync("http://localhost:5049/api/Destinations?id=" + id);
        return RedirectToAction("Index");
    }
}