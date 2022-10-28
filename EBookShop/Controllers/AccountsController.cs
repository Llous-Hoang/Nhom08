using EBookShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace EBookShop.Controllers
{
    public class AccountsController : Controller
    {
        private EBookShopContext _context;
        public AccountsController(EBookShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
