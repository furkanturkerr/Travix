using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travix.Dtos.AdminDtos.BlogDtos;

namespace Travix.Controllers;

public class BlogController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BlogController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
    
        var response = await client.GetAsync("http://localhost:5049/api/Blogs/BlogTrue");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultBlogDto>>(jsonData);
            return View(value ?? new List<ResultBlogDto>());
        }
    
        return View(new List<ResultBlogDto>());
    }
}