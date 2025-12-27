using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Areas.Dashboard.Components;

public class DashboardHeadViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
