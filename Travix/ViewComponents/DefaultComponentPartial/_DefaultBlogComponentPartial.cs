using Microsoft.AspNetCore.Mvc;

namespace Travix.ViewComponents.DefaultComponentPartial;

public class _DefaultBlogComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}