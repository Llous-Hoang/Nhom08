using Microsoft.AspNetCore.Mvc;
using EBookShop.Data;
using Microsoft.EntityFrameworkCore;
using EBookShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EBookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private EBookShopContext _context;
        public ProductsController(EBookShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products;
            return View(products);
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

        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SKU,Name,Description,Price,Stock,ProductTypeId,Image,Status")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name", product.ProductTypeId);
            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
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
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Products == null)
        //    {
        //        return Problem("Entity set 'EshopContext.Products'  is null.");
        //    }
        //    var product = await _context.Products.FindAsync(id);
        //    if (product != null)
        //    {
        //        _context.Products.Remove(product);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
