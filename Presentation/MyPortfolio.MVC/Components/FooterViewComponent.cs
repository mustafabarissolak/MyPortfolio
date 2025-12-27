using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Components;

public class FooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
