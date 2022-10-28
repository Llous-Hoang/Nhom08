using EBookShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace EBookShop.Controllers
{
    public class ProductsController : Controller
    {
        private EBookShopContext _context;
        public ProductsController(EBookShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
