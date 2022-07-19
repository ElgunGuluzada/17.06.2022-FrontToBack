using _17._06._2022_FrontToBack.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _17._06._2022_FrontToBack.Areas.adminPanel.Controllers
{
    [Area("adminpanel")] 
    [Authorize(Roles ="Admin , SuperAdmin")]
    public class DashboardController : Controller
    {

       private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var curUser = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.AdminUser = curUser.Fullname;
            return View();
        }

    }
}
