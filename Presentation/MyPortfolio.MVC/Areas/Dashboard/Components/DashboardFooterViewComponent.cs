using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Areas.Dashboard.Components;

public class DashboardFooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}