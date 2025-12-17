using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntigra.Ecommerce.Platform.Application.Contract.Cart;
public interface ICartService
{
    Task AddToCartAsync(int productId);
    Task RemoveFromCartAsync(int productId);
    Task<CartSummary> GetCartSummaryAsync();
    Task<int> GetCartItemCountAsync();
}
