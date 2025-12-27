using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.MVC.Components;

public class ClientsViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
