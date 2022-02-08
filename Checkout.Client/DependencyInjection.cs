using Checkout.Client.Cart;
using Checkout.Client.Cart.Providers;
using Checkout.Client.Cart.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.Client;

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

