using Checkout.Application.Cart;
using Checkout.Application.Cart.Providers;
using Checkout.Application.Cart.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.Application;

public static class DependencyInjection
{
    public static IServiceCollection Register(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ICartService, CartService>();
        serviceCollection.AddSingleton<ICartRepository, CartRepository>();
        serviceCollection.AddSingleton<IDiscountRepository, DiscountRepository>();
        serviceCollection.AddSingleton<ICartTotalPriceProvider, CartTotalPriceProvider>();

        return serviceCollection;
    }
}

