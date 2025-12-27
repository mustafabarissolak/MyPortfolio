using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Components;

public class ExperienceViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
