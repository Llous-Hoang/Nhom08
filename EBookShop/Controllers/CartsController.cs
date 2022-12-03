using EBookShop.Data;
using EBookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EBookShop.Controllers
{
    public class CartsController : Controller
    {
        private EBookShopContext _context;
        public CartsController(EBookShopContext context)
        {
            _context = context;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            string username = "admin";
            var eshopContext = _context.Carts.Include(c => c.Account)
                                             .Include(c => c.Product)
                                             .Where(c => c.Account.username == username);
            return View(await eshopContext.ToListAsync());
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(c => c.Account)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "username");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            return View();
        }

        // POST: Carts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountId,ProductId,Quantity")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "username", cart.AccountId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", cart.ProductId);
            return View(cart);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "username", cart.AccountId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", cart.ProductId);
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountId,ProductId,Quantity")] Cart cart)
        {
            if (id != cart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "username", cart.AccountId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", cart.ProductId);
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(c => c.Account)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        [HttpPost]
        public IActionResult DeleteAll()
        {
            string username = "admin";
            var carts = _context.Carts.Include(c => c.Account)
                          .Include(c => c.Product)
                          .Where(c => c.Account.username == username);
            foreach (var item in carts)
            {
                _context.Carts.Remove(item);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Purchase()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Purchase(string ShippingAddress, string ShippingPhone)
        {
            string username = "admin";

            var carts = _context.Carts.Include(c => c.Account)
                                      .Include(c => c.Product)
                                      .Where(c => c.Account.username == username);

            var accountId = _context.Accounts.FirstOrDefault(a => a.username == username).Id;
            var total = carts.Sum(c => c.Product.Price * c.Quantity);

            Invoice invoice = new Invoice
            {
                Code = DateTime.Now.ToString("yyyyMMddhhmmss"),
                AccountId = accountId,
                IssuedDate = DateTime.Now,
                ShippingAddress = ShippingAddress,
                ShippingPhone = ShippingPhone,
                Total = total,
                Status = true
            };
            _context.Invoices.Add(invoice);
            _context.SaveChanges();

            foreach (var item in carts)
            {
                InvoiceDetail detail = new InvoiceDetail
                {
                    InvoiceId = invoice.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Product.Price
                };
                _context.InvoiceDetails.Add(detail);
                _context.Carts.Remove(item);

                item.Product.Stock -= item.Quantity;
                _context.Products.Update(item.Product);
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
    }
}
