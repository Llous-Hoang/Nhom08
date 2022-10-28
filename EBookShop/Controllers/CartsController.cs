using EBookShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace EBookShop.Controllers
{
    public class CartsController : Controller
    {
        private EBookShopContext _context;
        public CartsController(EBookShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
