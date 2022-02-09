using Checkout.Application.Cart.Repositories;
using Moq;
using System.Collections.Generic;
using Checkout.Application.Cart.Models;
using Checkout.Application.Cart.Providers;

namespace Checkout.UnitTests.CartService;

public class CartTotalPriceProviderFixture
{
    private Mock<ICartRepository> _cartRepositoryMock = new Mock<ICartRepository>();
    private Mock<IDiscountRepository> _discountRepositoryMock = new Mock<IDiscountRepository>();

    private List<CartItem> _cartItems = new List<CartItem>();
    private List<Discount> _discounts = new List<Discount>();

    public ICartTotalPriceProvider CreateSut()
    {
        _cartRepositoryMock.Setup(x => x.GetItems()).Returns(_cartItems);
        _discountRepositoryMock.Setup(x => x.GetAll()).Returns(_discounts);

        return new CartTotalPriceProvider(_cartRepositoryMock.Object, _discountRepositoryMock.Object);
    }

    public CartTotalPriceProviderFixture WithCartItem(Product product, int count)
    {
        _cartItems.Add(new CartItem() { Product = product, Count = count });
        return this;
    }

    public CartTotalPriceProviderFixture WithDiscount(Discount discount)
    {
        _discounts.Add(discount);
        return this;
    }
}

