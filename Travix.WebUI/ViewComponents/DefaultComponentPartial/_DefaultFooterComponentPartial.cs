using Microsoft.AspNetCore.Mvc;

namespace Travix.ViewComponents.DefaultComponentPartial;

public class _DefaultFooterComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}