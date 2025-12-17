using Ntigra.Ecommerce.Platform.Domain.Shared.Results;

namespace Ntigra.Ecommerce.Platform.Application.Contract.Cart;
public interface ICartService
{
    Task<Response<string>> AddToCartAsync(int productId);
    Task<Response<string>> RemoveFromCartAsync(int productId);
    Task<Response<CartSummaryResponseDto>> GetCartSummaryAsync();
    Task<int> GetCartItemCountAsync();
}
