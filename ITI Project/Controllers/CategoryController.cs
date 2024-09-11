using ITI_Project.Context;
using ITI_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI_Project.Controllers
{
    public class CategoryController : Controller
    {
        MarketContext marketContext = new MarketContext();

        [HttpGet]
        public IActionResult Index()
        {
            var categories = marketContext.Categories;
            return View(categories);
        }

        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var category = marketContext.Categories
                                        .FirstOrDefault(c => c.CategoryId == id);
            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Are Reqired");
                return View();
            }
            marketContext.Categories.Update(category);
            marketContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = marketContext.Categories
                                        .FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Are Reqired");
                return View();
            }
            marketContext.Categories.Update(category);
            marketContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = marketContext.Categories
                                        .FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var category = marketContext.Categories.Find(id);
            if (category != null)
            {
                marketContext.Categories.Remove(category);
                marketContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
