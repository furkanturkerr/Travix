using Microsoft.AspNetCore.Mvc;

namespace Travix.ViewComponents.AdminComponentPartial;

public class _AdminNavbarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}