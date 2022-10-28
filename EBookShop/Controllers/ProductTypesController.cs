using EBookShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace EBookShop.Controllers
{
    public class ProductTypesController : Controller
    {
        private EBookShopContext _context;
        public ProductTypesController(EBookShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
