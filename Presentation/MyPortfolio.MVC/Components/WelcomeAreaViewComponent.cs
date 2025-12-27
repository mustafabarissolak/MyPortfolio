using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Components;

public class WelcomeAreaViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
