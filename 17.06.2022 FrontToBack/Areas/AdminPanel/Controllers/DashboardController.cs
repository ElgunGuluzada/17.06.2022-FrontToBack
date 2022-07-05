using Microsoft.AspNetCore.Mvc;

namespace _17._06._2022_FrontToBack.Areas.adminPanel.Controllers
{
    [Area("adminpanel")] 
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }
    }
}
