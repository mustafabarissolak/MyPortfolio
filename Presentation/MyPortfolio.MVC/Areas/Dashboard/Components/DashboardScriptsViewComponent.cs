using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Areas.Dashboard.Components;

public class DashboardScriptsViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
