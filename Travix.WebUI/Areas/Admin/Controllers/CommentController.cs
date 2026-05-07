using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travix.Dtos.AdminDtos.CommentDtos;

namespace Travix.Areas.Admin.Controllers;
[Area("Admin")]

public class CommentController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CommentController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        
        var response = await client.GetAsync("http://localhost:5049/api/Comments");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            return View(value);
        }
        
        return View();
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCommentDto Comment)
    {
        var client = _httpClientFactory.CreateClient();
        
        var json = JsonConvert.SerializeObject(Comment);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5049/api/Comments", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(Comment);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("http://localhost:5049/api/Comments/" + id);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateCommentDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCommentDto CommentDto)
    {
        var client = _httpClientFactory.CreateClient();

        var json = JsonConvert.SerializeObject(CommentDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5049/api/Comments", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(CommentDto);   
    }

    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        await client.DeleteAsync("http://localhost:5049/api/Comments?id=" + id);
        return RedirectToAction("Index");
    }
}