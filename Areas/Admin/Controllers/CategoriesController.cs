using E_commerce_mvc.Data;
using E_commerce_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }
        public IActionResult Delete(int id)
        {
            if (context.Categories.Find(id) is not null)
            {
                var category = context.Categories.Find(id);
                context.Categories.Remove(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Create()
        {

            return View("Create", new Category());
        }

        [HttpPost]
        public IActionResult Create(Category request)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", request);
            }
            var flag = context.Categories.Any(c => c.Name == request.Name);
            if (flag)
            {
                ModelState.AddModelError("Name", "Category name already exists.");
                return View("Create", request);
            }
            context.Categories.Add(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
