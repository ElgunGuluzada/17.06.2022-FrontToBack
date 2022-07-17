using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _17._06._2022_FrontToBack.Areas.adminPanel.Controllers
{
    [Area("adminpanel")] 
    [Authorize(Roles ="Admin , SuperAdmin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
