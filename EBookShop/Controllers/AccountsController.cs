using EBookShop.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBookShop.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

        //GET:Accounts/Create
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
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        //Get: Accounts/Edit/Id
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,Email,Phone,Address,FullName,IsAdmin,Avatar,Status")] Account account)
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

        //Get: Accounts/Delete/Id
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

        //POST: Accounts/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accounts == null)
            {
                return Problem("Entity set 'EshopContext.Account'  is null.");
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
