using Microsoft.Extensions.DependencyInjection;
using Ntigra.Ecommerce.Platform.Domain.Managers;

namespace Ntigra.Ecommerce.Platform.Domain;
public static class DependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddTransient<DiscountManager>();
        return services;
    }
}
