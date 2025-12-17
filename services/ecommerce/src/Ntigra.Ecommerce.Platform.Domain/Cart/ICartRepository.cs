using Ntigra.Ecommerce.Platform.Application.Contract.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntigra.Ecommerce.Platform.Domain.Cart;
public interface ICartRepository
{
    Task AddAsync(int productId);
    Task RemoveAsync(int productId);
    Task<List<CartItem>> GetCartItemsAsync();
}
