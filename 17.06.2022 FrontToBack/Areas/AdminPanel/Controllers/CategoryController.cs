using _17._06._2022_FrontToBack.DAL;
using _17._06._2022_FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17._06._2022_FrontToBack.Areas.AdminPanel.Controllers
{
    [Area("adminpanel")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool existCategoryName = _context.Categories.Any(c => c.Name.ToLower().Trim() == category.Name.ToLower().Trim());
            if (existCategoryName)
            {
                ModelState.AddModelError("Name", "The name of category is exist");
                return View();
            }

            Category newCategory = new Category
            {
                Name = category.Name.ToUpper(),
                Description = category.Description,
            };

            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Category dbCategory = await _context.Categories.FindAsync(id);
            if (dbCategory == null) return NotFound();

            return View(dbCategory);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Category dbCategory = await _context.Categories.FindAsync(id);
            if (dbCategory == null) return NotFound();

            return View(dbCategory);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Category dbCategory = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (dbCategory == null)
            {
                return View();
            }

            Category dbCategoryName = _context.Categories.FirstOrDefault(c => c.Name.ToLower().Trim() == category.Name.ToLower().Trim());

            if (dbCategoryName != null)
            {
                if (dbCategory.Name != dbCategoryName.Name)
                {
                    ModelState.AddModelError("Name", "This Name already was taken");
                    return View();

                }
            }
            dbCategory.Name = category.Name;
            dbCategory.Description = category.Description;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Category dbCategory = await _context.Categories.FindAsync(id);
            if (dbCategory == null) return NotFound();
            _context.Categories.Remove(dbCategory);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }
    }
}
