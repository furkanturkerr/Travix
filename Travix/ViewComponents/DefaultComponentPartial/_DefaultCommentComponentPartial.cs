using Microsoft.AspNetCore.Mvc;

namespace Travix.ViewComponents.DefaultComponentPartial;

public class _DefaultCommentComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}