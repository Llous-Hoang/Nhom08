using EBookShop.Models;

using Microsoft.EntityFrameworkCore;

namespace EBookShop.Data
{
    public class EBookShopContext : DbContext
    {
        public EBookShopContext(DbContextOptions<EBookShopContext>options):base (options)
        {

        }
        public DbSet<Account> Accounts { get; set; } = default!;

        public DbSet<Cart> Carts { get; set; } = default!;

        public DbSet<Invoice> Invoices { get; set; } = default!;

        public DbSet<InvoiceDetail> InvoiceDetails { get; set; } = default!;

        public DbSet<Product> Products { get; set; } = default!;

        public DbSet<ProductType> ProductTypes { get; set; } = default!;

    }
}
