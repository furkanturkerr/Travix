using Microsoft.AspNetCore.Mvc;

namespace Travix.ViewComponents.AdminComponentPartial;

public class _AdminHeaderComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}