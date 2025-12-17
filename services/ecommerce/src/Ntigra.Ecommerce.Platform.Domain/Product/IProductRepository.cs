using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntigra.Ecommerce.Platform.Domain.Product;
public interface IProductRepository
{
    Task<List<Product>> GetAllProductsAsync();
}
