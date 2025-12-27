using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Components;

public class ContactViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
