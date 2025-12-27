using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Components;

public class HeadViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
