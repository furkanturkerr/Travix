using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travix.Dtos.MessageDtos;

namespace Travix.Controllers;

public class ContactController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ContactController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(CreateMessageDto message)
    {
        var client = _httpClientFactory.CreateClient();
        var json = JsonConvert.SerializeObject(message);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5049/api/Messages", content);

        if (response.IsSuccessStatusCode)
        {
            TempData["Basarili"] = "Mesajınız alındı, teşekkürler!";
        }
        else
        {
            TempData["Basarisiz"] = "Mesajınız gönderilemedi!";
        }

        return RedirectToAction("Index");
    }
}