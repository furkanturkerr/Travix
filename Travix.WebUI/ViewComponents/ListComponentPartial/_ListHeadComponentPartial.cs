using Microsoft.AspNetCore.Mvc;

namespace Travix.ViewComponents.ListComponentPartial;

public class _ListHeadComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}