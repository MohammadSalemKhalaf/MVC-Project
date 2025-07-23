using E_commerce_mvc.Data;
using E_commerce_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            ViewBag.Products = context.Products.ToList();
            return View();
        }
        public IActionResult Delete(int id)
        {
            if (context.Products.Find(id) is not null)
            {
                var product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.Categories = context.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product request, IFormFile image)
        {

            var fileName = Guid.NewGuid().ToString(); //U382340932U2234
            fileName = fileName + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images",fileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                image.CopyTo(stream);
            }

            request.Image = fileName;
            context.Products.Add(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

