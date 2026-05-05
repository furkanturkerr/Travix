using Microsoft.AspNetCore.Mvc;

namespace Travix.Controllers;

public class BlogController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}