using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ntigra.Ecommerce.Platform.Domain.Product;
using Ntigra.Ecommerce.Platform.Infrastructure.EntityFrameworkCore;

namespace Ntigra.Ecommerce.Platform.Infrastructure.Repository;
public sealed class ProductRepository(AppDbContext context ,
    ILogger<ProductRepository> log) : IProductRepository
{
    public async Task<List<Product>> GetAllProductsAsync()
    {
            return await context.Products
                .Where(p => p.IsActive)
                .AsNoTracking()
                .ToListAsync();
        }
}
