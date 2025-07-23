using E_commerce_mvc.Data;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_mvc.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        public ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index()
        {
            ViewBag.categories = context.Categories.ToList();
            ViewBag.products = context.Products.ToList();
            return View();
        }
    }
}

