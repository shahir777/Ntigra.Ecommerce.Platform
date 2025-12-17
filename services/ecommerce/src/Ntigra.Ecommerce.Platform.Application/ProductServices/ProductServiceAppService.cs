using Ntigra.Ecommerce.Platform.Application.Contract.Product;
using Ntigra.Ecommerce.Platform.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntigra.Ecommerce.Platform.Application.ProductServices;
public sealed class ProductServiceAppService(IProductRepository productRepository) : IProductService
{
    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        try
        {
            var products = await productRepository.GetAllProductsAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                DiscountPercent = p.DiscountPercent
            }).ToList();
        }
        catch(Exception)
        {
            throw;
        }
        
    }
}
