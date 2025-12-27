using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Areas.Dashboard.Components;

public class DashboardNavbarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
