using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Components;

public class ScriptsViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
