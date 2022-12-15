using EBookShop.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBookShop.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace EBookShop.Controllers
{
    public class AccountsController : Controller
    {
        private EBookShopContext _context;
        public AccountsController(EBookShopContext context)
        {
            _context = context;
        }

        //GET: Accounts

        public async Task<IActionResult> Index()
        {
            ViewBag.username = HttpContext.Request.Cookies["username"];
            return View(await _context.Accounts.ToListAsync());
        }

        //Get: Account/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accounts == null){
                return NotFound();
            }

            var account = await _context.Accounts.FirstOrDefaultAsync(
                                                    m=>m.Id==id);

            if (account == null) { 
                return NotFound();
            }

            return View(account);
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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,username,password,email,phone,address,fullname")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        } 
    }
}
