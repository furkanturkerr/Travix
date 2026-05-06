using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travix.Dtos.AdminDtos.BlogDtos;

namespace Travix.Areas.Admin.Controllers;
[Area("Admin")]

public class BlogController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BlogController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> BlogList()
    {
        var client = _httpClientFactory.CreateClient();
        
        var response = await client.GetAsync("http://localhost:5049/api/Blogs");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultBlogDto>>(jsonData);
            return View(value);
        }
        
        return View();
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBlogDto Blog)
    {
        var client = _httpClientFactory.CreateClient();
        
        var json = JsonConvert.SerializeObject(Blog);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5049/api/Blogs", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("BlogList");
        }
        return View(Blog);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("http://localhost:5049/api/Blogs/" + id);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateBlogDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateBlogDto BlogDto)
    {
        var client = _httpClientFactory.CreateClient();

        var json = JsonConvert.SerializeObject(BlogDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5049/api/Blogs", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("BlogList");
        }
        return View(BlogDto);   
    }

    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        await client.DeleteAsync("http://localhost:5049/api/Blogs?id=" + id);
        return RedirectToAction("BlogList");
    }
}