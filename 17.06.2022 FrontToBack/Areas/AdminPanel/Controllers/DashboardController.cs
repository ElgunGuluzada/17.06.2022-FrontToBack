using Microsoft.AspNetCore.Mvc;

namespace _17._06._2022_FrontToBack.Areas.adminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
