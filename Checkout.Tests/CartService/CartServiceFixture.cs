using Checkout.Client;
using Checkout.Client.Cart;
using Checkout.Client.Cart.Models;
using Checkout.Client.Cart.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.Tests
{
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
}
