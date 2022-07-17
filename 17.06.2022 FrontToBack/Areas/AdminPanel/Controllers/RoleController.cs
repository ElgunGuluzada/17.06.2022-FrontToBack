using _17._06._2022_FrontToBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace _17._06._2022_FrontToBack.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly SignInManager<AppUser> _signInManager;

        public RoleController(UserManager<AppUser> userManager, RoleManager<IdentityRole> rolemanager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _rolemanager = rolemanager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View(_rolemanager.Roles.ToList());
        }

        public IActionResult Create()
        {
            return View(_rolemanager.Roles.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(string role)
        {
            await _rolemanager.CreateAsync(new IdentityRole { Name = role });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await _rolemanager.FindByIdAsync(id);
            await _rolemanager.DeleteAsync(result);
            return RedirectToAction("Index");
        }
    }
}
