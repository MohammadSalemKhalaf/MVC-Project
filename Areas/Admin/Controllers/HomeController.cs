using E_commerce_mvc.Data;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index()
        {
            return View();
        }
    }
}
