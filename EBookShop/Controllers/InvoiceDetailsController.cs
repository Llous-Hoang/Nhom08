using EBookShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace EBookShop.Controllers
{
    public class InvoiceDetailsController : Controller
    {

        private EBookShopContext _context;
        public InvoiceDetailsController(EBookShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
