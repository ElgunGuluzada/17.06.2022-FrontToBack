using _17._06._2022_FrontToBack.DAL;
using _17._06._2022_FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17._06._2022_FrontToBack.ViewComponents
{
    public class ProductViewComponent: ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int skip)
        {
            List<Product> products = _context.Products.Include(p => p.Category).Skip(skip).ToList();
            return View(await Task.FromResult(products));
        }
    }
}
