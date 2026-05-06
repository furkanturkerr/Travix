using Microsoft.AspNetCore.Mvc;

namespace Travix.ViewComponents.AdminComponentPartial;

public class _AdminHeadComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}