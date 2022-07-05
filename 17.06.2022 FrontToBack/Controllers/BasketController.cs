using _17._06._2022_FrontToBack.DAL;
using Microsoft.AspNetCore.Mvc;
using _17._06._2022_FrontToBack.Models;
using _17._06._2022_FrontToBack.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _17._06._2022_FrontToBack.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(int? id)
        {
            if (id == null) return NotFound();

            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();

            List<BasketVM> products;

            if (Request.Cookies["basket"] == null)
            {
                products = new List<BasketVM>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>((Request.Cookies["basket"]));
            }
            BasketVM existProduct = products.Find(p => p.Id == id);
            if (existProduct == null)
            {
                BasketVM basketVM = new BasketVM
                {
                    Id = dbProduct.Id,
                    ProductCount = 1,
                    Price = dbProduct.Price
                };
                products.Add(basketVM);
            }
            else
            {
                existProduct.ProductCount++;
            }

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });
            double price=0;
            double count=0;

            foreach(var product in products)
            {
                price += product.Price*product.ProductCount;
                count += product.ProductCount;
            }
            var obj = new
            {
                Price = price,
                Count=count,
            };
            return Ok(obj);

            //return RedirectToAction("index", "home");
        }

        public IActionResult ShowItem()
        {
            string basket = Request.Cookies["basket"];
            List<BasketVM> products;
            if (basket != null)
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                foreach (var item in products)
                {
                    Product dbProduct = _context.Products.Include(c=>c.Category).FirstOrDefault(p => p.Id == item.Id);
                    item.Price = dbProduct.Price;
                    item.Name = dbProduct.Name;
                    item.Category = dbProduct.Category.Name;
                    item.ImageUrl = dbProduct.ImageUrl;
                }
            }
            else
            {
                products = new List<BasketVM>();
            }
            return View(products);
        }
        public IActionResult min(int? id)
        {
            List<BasketVM> products;
            string basket = Request.Cookies["basket"];
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM existProduct = products.Find(p => p.Id == id);
            if (existProduct.ProductCount > 1)
            {
                existProduct.ProductCount--;
            }
            else
            {
                products.Remove(existProduct);
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });
            var Obj = new
            {
                existProduct.ProductCount,
            };
            //return RedirectToAction("showitem", "basket");
            return Ok(Obj);
        }
        public IActionResult plus(int? id)
        {
            List<BasketVM> products;
            string basket = Request.Cookies["basket"];
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM existProduct = products.Find(p => p.Id == id);
            existProduct.ProductCount++;
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });
            return RedirectToAction("showitem", "basket");
        }
        public IActionResult removeItem(int? id)
        {
            List<BasketVM> products;
            string basket = Request.Cookies["basket"];
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

            BasketVM existProduct = products.Find(p => p.Id == id);
            products.Remove(existProduct);
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });
            return RedirectToAction("showitem", "basket");
        }
    }
}
