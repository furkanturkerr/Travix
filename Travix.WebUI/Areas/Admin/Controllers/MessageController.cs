using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travix.Dtos.MessageDtos;

namespace Travix.Areas.Admin.Controllers;
[Area("Admin")]
public class MessageController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MessageController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        
        var response = await client.GetAsync("http://localhost:5049/api/Messages");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsonData);
            return View(value);
        }
        
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("http://localhost:5049/api/Messages/" + id);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateMessageDto>(jsonData);
            return View(values);
        }
        return View();
    }

    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        await client.DeleteAsync("http://localhost:5049/api/Messages?id=" + id);
        return RedirectToAction("Index");
    }
}