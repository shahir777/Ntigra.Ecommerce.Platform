using Microsoft.Extensions.Logging;
using Ntigra.Ecommerce.Platform.Application.Contract.Product;
using Ntigra.Ecommerce.Platform.Domain.Product;
using Ntigra.Ecommerce.Platform.Domain.Shared.Enums;
using Ntigra.Ecommerce.Platform.Domain.Shared.Exceptions;
using Ntigra.Ecommerce.Platform.Domain.Shared.Helper;
using Ntigra.Ecommerce.Platform.Domain.Shared.Helper.Extensions;
using Ntigra.Ecommerce.Platform.Domain.Shared.Results;

namespace Ntigra.Ecommerce.Platform.Application.ProductServices;
public sealed class ProductServiceAppService(IProductRepository productRepository,
    ILogger<ProductServiceAppService> log) : IProductService
{
    public async Task<Response<List<ProductResponseDto>>> GetAllProductsAsync()
    {
        try
        {
            var products = await productRepository.GetAllProductsAsync();
            
            var response = products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                DiscountPercent = p.DiscountPercent
                
            }).ToList();
            
            log.Debug(JsonHelper.SerializeWithOptions(response));

            if (response.Count > 0)
            {
                log.Success("Product list found");
                return Response<List<ProductResponseDto>>.Success(data: response);
            }
            
            log.Success("Product list empty");
            return Response<List<ProductResponseDto>>.Success(ReturnCode.ProductNotFound);
        }
        catch(Exception ex)
        {
            log.Exception(ex);
            return Response<List<ProductResponseDto>>.Fail(ReturnCode.UnhandledException);
        }
        
    }
}
