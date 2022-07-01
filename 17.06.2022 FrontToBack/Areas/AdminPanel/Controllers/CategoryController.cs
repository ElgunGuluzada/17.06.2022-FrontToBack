using Microsoft.AspNetCore.Mvc;

namespace _17._06._2022_FrontToBack.Areas.AdminPanel.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
