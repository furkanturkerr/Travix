using Microsoft.AspNetCore.Mvc;

namespace Travix.ViewComponents.DefaultComponentPartial;

public class _DefaultDestinationComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}