using Microsoft.AspNetCore.Mvc;

namespace EBookShop.Controllers
{
    public class ViewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
