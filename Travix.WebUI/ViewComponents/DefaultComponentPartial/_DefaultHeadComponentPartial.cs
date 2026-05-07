using Microsoft.AspNetCore.Mvc;

namespace Travix.ViewComponents.DefaultComponentPartial;

public class _DefaultHeadComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}