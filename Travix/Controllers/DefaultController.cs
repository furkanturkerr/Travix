using Microsoft.AspNetCore.Mvc;

namespace Travix.Controllers;

public class DefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}