using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Components;

public class EducationViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
