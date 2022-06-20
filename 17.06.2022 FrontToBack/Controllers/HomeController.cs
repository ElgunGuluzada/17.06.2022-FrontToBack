using Microsoft.AspNetCore.Mvc;

namespace _17._06._2022_FrontToBack.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
