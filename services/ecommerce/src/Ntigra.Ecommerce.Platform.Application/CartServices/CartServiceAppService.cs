using Ntigra.Ecommerce.Platform.Application.Contract.Cart;
using Ntigra.Ecommerce.Platform.Domain.Cart;

namespace Ntigra.Ecommerce.Platform.Application.CartServices;
public sealed class CartServiceAppService(ICartRepository cartRepository) : ICartService
{
    private const decimal PRICE_THRESHOLD = 100;

    public async Task AddToCartAsync(int productId)
    {
        try
        {
            await cartRepository.AddAsync(productId);
        }
        catch(Exception)
        {
            throw;
        }
    }

    public async Task RemoveFromCartAsync(int productId)
    {
        try
        {
            await cartRepository.RemoveAsync(productId);

        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CartSummary> GetCartSummaryAsync()
    {
        try
        {
            var cartItems = await cartRepository.GetCartItemsAsync();
            var totalPrice = cartItems.Sum(x => x.Product.Price);
            var hasDiscount = totalPrice >= PRICE_THRESHOLD;

            var items = cartItems.Select(item =>
            {
                var discount = hasDiscount
                    ? item.Product.Price * item.Product.DiscountPercent / 100m
                    : 0;

                return new CartItemSummary
                {
                    ProductId = item.ProductId,
                    ProductName = item.Product.Name,
                    Description = item.Product.Description,
                    OriginalPrice = item.Product.Price,
                    DiscountPercent = item.Product.DiscountPercent,
                    DiscountAmount = discount,
                    Quantity = item.Quantity
                };
            }).ToList();

            var totalDiscount = items.Sum(x => x.DiscountAmount);

            return new CartSummary
            {
                Items = items,
                TotalPrice = totalPrice,
                TotalDiscount = totalDiscount
            };
        }
        catch(Exception)
        {
            throw;
        }
    }

    public async Task<int> GetCartItemCountAsync()
    { 
        return await cartRepository.GetCartItemCountAsync();
    } 
}