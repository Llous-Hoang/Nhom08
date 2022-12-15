using EBookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace EBookShop.Data
{
    public partial class EBookShopContext : DbContext
    {

        public EBookShopContext(DbContextOptions<EBookShopContext>options):base (options)
        {
            
        }
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

    }
}
