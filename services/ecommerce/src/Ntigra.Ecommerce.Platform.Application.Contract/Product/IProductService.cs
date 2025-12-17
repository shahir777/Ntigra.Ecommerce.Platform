using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntigra.Ecommerce.Platform.Application.Contract.Product;
public interface IProductService
{
    Task<List<ProductDto>> GetAllProductsAsync();
}
