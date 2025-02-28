using Microsoft.AspNetCore.Mvc;

namespace TicketSystem.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Ticket");
        }

        return View();
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }
    
    
}