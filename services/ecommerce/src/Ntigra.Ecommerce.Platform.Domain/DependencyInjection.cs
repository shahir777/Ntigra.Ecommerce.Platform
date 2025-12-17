using Microsoft.Extensions.DependencyInjection;
using Ntigra.Ecommerce.Platform.Domain.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntigra.Ecommerce.Platform.Domain;
public static class DependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        //services.AddTransient<ICartPricingCalculator, CartPricingCalculator>();
        return services;
    }
}
