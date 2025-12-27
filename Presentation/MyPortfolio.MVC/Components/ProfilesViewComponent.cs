using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Components;

public class ProfilesViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
