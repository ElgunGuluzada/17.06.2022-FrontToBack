using _17._06._2022_FrontToBack.DAL;
using _17._06._2022_FrontToBack.Models;
using _17._06._2022_FrontToBack.Extentions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace FrontToBack.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin , SuperAdmin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_context.Products.Include(p => p.Category).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name"); ;

            if (product.Photo == null)
            {
                ModelState.AddModelError("Photo", "Select Image");
                return View();
            }
            if (!product.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Only Image Files");
                return View();
            }

            if (product.Photo.ValidSize(1000))
            {
                ModelState.AddModelError("Photo", "Size is higher max 1mb");
                return View();
            }

            Product newProduct = new Product
            {
                Price = product.Price,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Count=product.Count,
                ImageUrl = product.Photo.SaveImage(_env, "img")
            };
            await _context.Products.AddAsync(newProduct);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (dbProduct == null) return NotFound();

            return View(dbProduct);
        }

        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name"); ;
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();

            return View(dbProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Product product)
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            Product dbProduct = await _context.Products.FindAsync(product.Id);
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (dbProduct == null)
            {
                return View();
            }
            string imgUrl = "";
            if (product.Photo == null)
            {
                 imgUrl= dbProduct.ImageUrl;
            }
            else
            {
                if (!product.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Only Image Files");
                    return View();
                }

                if (product.Photo.ValidSize(1000))
                {
                    ModelState.AddModelError("Photo", "Size is higher max 1mb");
                    return View();
                }
                 imgUrl = product.Photo.SaveImage(_env, "img");

            }
            string oldImg= dbProduct.ImageUrl;
            string path = Path.Combine(_env.WebRootPath, "img", oldImg);
            _17._06._2022_FrontToBack.Helpers.Helper.DeleteImage(path);

            Product newProduct = new Product
            {
                Price = product.Price,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Count=product.Count,
                ImageUrl=imgUrl,
            };

           
            //string UploadPath = ConfigurationManager.AppSettings["ProductImagePath"].ToString();
            //ViewBag.Path = UploadPath;
            
            _context.Products.Remove(dbProduct);
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            //return Ok(UploadPath);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();

            string path = Path.Combine(_env.WebRootPath, "img", dbProduct.ImageUrl);


            _17._06._2022_FrontToBack.Helpers.Helper.DeleteImage(path);

            _context.Products.Remove(dbProduct);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
