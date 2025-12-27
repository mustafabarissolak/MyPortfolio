using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Components;

public class AboutViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
