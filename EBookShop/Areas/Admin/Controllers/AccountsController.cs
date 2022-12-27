using EBookShop.Data;
using EBookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EBookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountsController : Controller
    {
        private EBookShopContext _context;
        private IWebHostEnvironment _environment;
        public AccountsController(EBookShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        //GET: Accounts

        public async Task<IActionResult> Index()
        {
            ViewBag.username = HttpContext.Request.Cookies["username"];
            return View(await _context.Accounts.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,username,password,email,phone,address,fullname,isAdmin,isActive")] Account account)
        {
            if (ModelState.IsValid)
            {

                if (account.ImageFile != null)
                {
                    var fileName = account.Id.ToString() + Path.GetExtension(account.ImageFile.FileName);
                    var uploadFolder = Path.Combine(_environment.WebRootPath, "images", "account");
                    var uploadPath = Path.Combine(uploadFolder, fileName);
                    using (FileStream fs = System.IO.File.Create(uploadPath))
                    {
                        account.ImageFile.CopyTo(fs);
                        fs.Flush();
                    }
                    account.avatar = fileName;
                    _context.Accounts.Add(account);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,username,password,email,phone,address,fullname,isAdmin,avatar,isActive")] Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
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
            return View(account);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accounts == null)
            {
                return Problem("Entity set 'EBookShopContext.Account'  is null.");
            }
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.username == username && a.password == password);
            if (account != null)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMsg = "Login failed!";
                return View();
            }
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}
