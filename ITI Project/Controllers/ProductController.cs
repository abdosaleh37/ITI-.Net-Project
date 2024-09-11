using ITI_Project.Context;
using ITI_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    public class ProductController : Controller
    {
        MarketContext marketContext = new MarketContext();

        [HttpGet]
        public IActionResult Index()
        {
            var products = marketContext.Products.Include(p => p.Category);
            return View(products);
        }

        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var product = marketContext.Products
                                       .Include(p => p.Category)
                                       .FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(marketContext.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Are Reqired");
                ViewBag.Categories = new SelectList(marketContext.Categories, "CategoryId", "Name");
                return View();
            }
            marketContext.Products.Add(product);
            marketContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = marketContext.Products
                                      .Include(p => p.Category)
                                      .FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(marketContext.Categories, "CategoryId", "Name");
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Are Reqired");
                ViewBag.Categories = new SelectList(marketContext.Categories, "CategoryId", "Name");
                return View();
            }
            marketContext.Products.Update(product);
            marketContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = marketContext.Products
                                       .FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var product = marketContext.Products.Find(id);
            if (product != null)
            {
                marketContext.Products.Remove(product);
                marketContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
