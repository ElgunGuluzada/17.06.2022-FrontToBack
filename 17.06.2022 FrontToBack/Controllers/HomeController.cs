using _17._06._2022_FrontToBack.DAL;
using _17._06._2022_FrontToBack.Models;
using _17._06._2022_FrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace _17._06._2022_FrontToBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
           _context = context;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.Sliders = _context.Sliders.ToList();
            homeVM.SliderContent = _context.SliderContents.FirstOrDefault();
            homeVM.Categories=_context.Categories.ToList();
            homeVM.Products=_context.Products.Include(p=>p.Category).ToList();
            homeVM.About = _context.About.FirstOrDefault();
            homeVM.AboutContents = _context.AboutContent.ToList();
            homeVM.Expert = _context.Expert.FirstOrDefault();
            homeVM.ExpertsInfo = _context.ExpertsInfo.ToList();
            homeVM.Blog = _context.Blog.FirstOrDefault();
            homeVM.BlogsContent = _context.BlogsContent.ToList();
            homeVM.Instagrams = _context.Instagram.ToList();
            return View(homeVM);
        }
        public IActionResult Detail(int? id,string name)
        {
            if(id== null)
            {
                return NotFound();
            }
            Product dbProduct=_context.Products.FirstOrDefault(p=>p.Id==id);
            if (dbProduct == null)  return NotFound();
            
            return View(dbProduct);
        }
    }
}
