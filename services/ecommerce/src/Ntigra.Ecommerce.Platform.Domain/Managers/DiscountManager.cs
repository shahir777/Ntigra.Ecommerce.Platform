using Ntigra.Ecommerce.Platform.Domain.Cart;
using Ntigra.Ecommerce.Platform.Domain.Shared.Consts;

namespace Ntigra.Ecommerce.Platform.Domain.Managers;

public class DiscountManager
{
    public bool HasDiscount(IReadOnlyCollection<CartItem> items)
    {
        var total = items.Sum(i => i.Product.Price * i.Quantity);
        return total >= SystemConfigConst.DiscountThreshold;
    }

    public decimal CalculateItemDiscount(CartItem item, bool hasDiscount)
    {
        if (!hasDiscount)
            return 0;

        return item.Product.Price * item.Product.DiscountPercent / 100m;
    }
}