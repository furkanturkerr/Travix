using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travix.Dtos.AdminDtos.CommentDtos;

namespace Travix.ViewComponents.DefaultComponentPartial;

public class _DefaultCommentComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultCommentComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
    
        var response = await client.GetAsync("http://localhost:5049/api/Comments/CommentTrue");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            return View(value ?? new List<ResultCommentDto>());
        }
    
        return View(new List<ResultCommentDto>());
    }
}