using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Areas.Dashboard.Controllers;

[Area("Dashboard")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
