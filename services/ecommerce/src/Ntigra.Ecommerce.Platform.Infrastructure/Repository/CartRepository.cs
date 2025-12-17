using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ntigra.Ecommerce.Platform.Domain.Cart;
using Ntigra.Ecommerce.Platform.Domain.Shared.Helper.Extensions;
using Ntigra.Ecommerce.Platform.Infrastructure.EntityFrameworkCore;

namespace Ntigra.Ecommerce.Platform.Infrastructure.Repository;
public sealed class CartRepository(AppDbContext context,
    ILogger<CartRepository> log) : ICartRepository
{
    public async Task AddAsync(int productId)
    {
        var cartItems = await context.CartItems
            .Where(x => x.ProductId == productId)
            .FirstOrDefaultAsync();

        if (cartItems is null)
        {
            log.Debug($"Cart is empty for for product : {productId}, adding product to cart");
            context.CartItems.Add(new CartItem
            {
                ProductId = productId,
                Quantity = 1
            });
        }
        else
        {
            log.Debug($"Adding quantiy to product : {productId}");
            cartItems.AddQuantity();
        }
        
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int productId)
    {
        var cartItems = await context.CartItems
            .Where(x => x.ProductId == productId)
            .FirstOrDefaultAsync();

        if (cartItems is null)
        {
            log.Debug($"Cart is empty for for product : {productId}");
        }
        else
        {
            log.Debug($"Adding quantiy to product : {productId}");
            cartItems.RemoveQuantity();
            if (cartItems.IsEmpty)
                context.CartItems.Remove(cartItems);
                
            await context.SaveChangesAsync();
        }
    }

    public async Task<List<CartItem>> GetCartItemsAsync()
    {
        return await context.CartItems
            .Include(x => x.Product)
            .AsNoTracking()
            .ToListAsync();
    }
}
