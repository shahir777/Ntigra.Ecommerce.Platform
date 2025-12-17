namespace Ntigra.Ecommerce.Platform.Domain.Product;
public interface IProductRepository
{
    Task<List<Product>> GetAllProductsAsync();
}
