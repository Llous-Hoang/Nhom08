using EBookShop.Data;
using EBookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PagedList;
using Microsoft.Extensions.Options;

namespace EBookShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly EBookShopContext _context;

        private readonly IWebHostEnvironment _environment;
        

        public ProductsController(EBookShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Products
        public async Task<IActionResult> Index(int p = 1)
        {
            var eshopContext = _context.Products.Include(p => p.ProductType);

            return View(await eshopContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            HttpContext.Session.Clear();
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string name, int minPrice = 0, int maxPrice = int.MaxValue)
        {
            var products = _context.Products.Where(p => p.Name.Contains(name))
                                            .Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
            return View(products);
        }

        //public ActionResult Index(int? page)
        //{

        //    // 1. Tham số int? dùng để thể hiện null và kiểu int
        //    // page có thể có giá trị là null và kiểu int.

        //    // 2. Nếu page = null thì đặt lại là 1.
        //    if (page == null) page = 1;

        //    // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
        //    // theo LinkID mới có thể phân trang.
        //    var links = (from l in db.Links
        //                 select l).OrderBy(x => x.LinkID);

        //    // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
        //    int pageSize = 3;

        //    // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
        //    // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
        //    int pageNumber = (page ?? 1);

        //    // 5. Trả về các Link được phân trang theo kích thước và số trang.
        //    return View(links.ToPagedList(pageNumber, pageSize));
        //}
    }
}
