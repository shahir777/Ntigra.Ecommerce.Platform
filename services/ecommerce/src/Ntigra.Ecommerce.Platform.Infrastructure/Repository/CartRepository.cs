using Microsoft.EntityFrameworkCore;
using Ntigra.Ecommerce.Platform.Application.Contract.Cart;
using Ntigra.Ecommerce.Platform.Domain.Cart;
using Ntigra.Ecommerce.Platform.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntigra.Ecommerce.Platform.Infrastructure.Repository;
public sealed class CartRepository(AppDbContext context) : ICartRepository
{
    public async Task AddAsync(int productId)
    {
        var item = new CartItem
        {
            ProductId = productId
        };

        context.CartItems.Add(item);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int productId)
    {
        var item = await context.CartItems
         .Where(x => x.ProductId == productId)
         .FirstOrDefaultAsync();

        if (item == null) return;

        context.CartItems.Remove(item);
        await context.SaveChangesAsync();
    }

    public async Task<List<CartItem>> GetCartItemsAsync()
    {
        return await context.CartItems
            .Include(x => x.Product)
            .AsNoTracking()
            .ToListAsync();
    }
}
