using Microsoft.AspNetCore.Mvc;

namespace Travix.ViewComponents.DefaultComponentPartial;

public class _DefaultHeaderComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}