using Microsoft.AspNetCore.Mvc;

namespace Travix.ViewComponents.DefaultComponentPartial;

public class _DefaultBannerComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}