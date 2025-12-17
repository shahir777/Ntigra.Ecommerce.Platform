using Microsoft.EntityFrameworkCore;
using Ntigra.Ecommerce.Platform.Domain.Product;
using Ntigra.Ecommerce.Platform.Infrastructure.EntityFrameworkCore;

namespace Ntigra.Ecommerce.Platform.Infrastructure.Repository;
public sealed class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await context.Products
            .Where(p => p.IsActive)
            .AsNoTracking()
            .ToListAsync();
    }
}
