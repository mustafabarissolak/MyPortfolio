using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Components;

public class HeaderViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
