using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Components;

public class PortfolioViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
