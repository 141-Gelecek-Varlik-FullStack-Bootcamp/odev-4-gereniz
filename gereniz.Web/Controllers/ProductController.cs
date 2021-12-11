using gereniz.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gereniz.Web.Controllers
{
    public class ProductController : Controller
    {
        [LoginFilter("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        
    }
}
