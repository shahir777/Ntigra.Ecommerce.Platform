using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ntigra.Ecommerce.Platform.Domain.Cart;
using Ntigra.Ecommerce.Platform.Domain.Product;
using Ntigra.Ecommerce.Platform.Infrastructure.EntityFrameworkCore;
using Ntigra.Ecommerce.Platform.Infrastructure.Repository;

namespace Ntigra.Ecommerce.Platform.Infrastructure
{
    public  static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DbConnection")
                )
            );

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();

            return services;
        }
    }
}
