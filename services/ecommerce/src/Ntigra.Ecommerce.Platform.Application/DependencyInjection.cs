using Microsoft.Extensions.DependencyInjection;
using Ntigra.Ecommerce.Platform.Application.CartServices;
using Ntigra.Ecommerce.Platform.Application.Contract.Cart;
using Ntigra.Ecommerce.Platform.Application.Contract.Product;
using Ntigra.Ecommerce.Platform.Application.ProductServices;
using Ntigra.Ecommerce.Platform.Domain;

namespace Ntigra.Ecommerce.Platform.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductServiceAppService>();
        services.AddScoped<ICartService, CartServiceAppService>();

        services.AddDomainServices();
        return services;
    }
       

}
