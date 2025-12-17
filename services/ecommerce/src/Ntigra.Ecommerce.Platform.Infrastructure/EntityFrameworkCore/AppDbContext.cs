using Microsoft.EntityFrameworkCore;
using Ntigra.Ecommerce.Platform.Domain.Cart;
using Ntigra.Ecommerce.Platform.Domain.Product;

namespace Ntigra.Ecommerce.Platform.Infrastructure.EntityFrameworkCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
               .HasOne(c => c.Product)
               .WithMany()
               .HasForeignKey(c => c.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
