using Checkout.Application;
using Checkout.Application.Cart;
using Checkout.Application.Cart.Models;
using Checkout.Application.Cart.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.IntegrationTests.CartService;

public class CartServiceFixture
{
    public readonly ServiceProvider serviceProvider = new ServiceCollection().Register().BuildServiceProvider();

    public ICartService CreateSut()
    {
        return serviceProvider.GetService<ICartService>();
    }

    public CartServiceFixture WithDiscount(Discount discount)
    {
        serviceProvider.GetService<IDiscountRepository>().Add(discount);

        return this;
    }
}

