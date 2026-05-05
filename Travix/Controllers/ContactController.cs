using Microsoft.AspNetCore.Mvc;

namespace Travix.Controllers;

public class ContactController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}