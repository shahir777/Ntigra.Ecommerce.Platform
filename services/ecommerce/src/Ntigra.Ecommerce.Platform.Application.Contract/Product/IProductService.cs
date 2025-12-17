using Ntigra.Ecommerce.Platform.Domain.Shared.Results;

namespace Ntigra.Ecommerce.Platform.Application.Contract.Product;
public interface IProductService
{
    Task<Response<List<ProductResponseDto>>> GetAllProductsAsync();
}
