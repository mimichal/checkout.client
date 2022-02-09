using Checkout.Application.Cart.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Checkout.UnitTests.CartService;

public class CartTotalPriceProviderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Should_Calculate_Total_Without_Discounts()
    {
        var vase = new Product() { Id = 1, Name = "Vase", BasePrice = 1.2M };
        var bigMug = new Product() { Id = 2, Name = "Big mug", BasePrice = 1M };
        var napkins = new Product() { Id = 3, Name = "Napkins", BasePrice = 0.45M };

        var fixture = new CartTotalPriceProviderFixture();

        var sut = fixture
            .WithCartItem(vase, 1)
            .WithCartItem(bigMug, 1)
            .WithCartItem(napkins, 1)
            .CreateSut();

        var total = sut.GetTotalPrice();

        total.Should().Be(2.65M);
    }

    [Test]
    public void Should_Calculate_Total_With_Discounts()
    {
        var vase = new Product() { Id = 1, Name = "Vase", BasePrice = 1.2M };
        var bigMug = new Product() { Id = 2, Name = "Big mug", BasePrice = 1M };
        var napkins = new Product() { Id = 3, Name = "Napkins", BasePrice = 0.45M };

        var bigMugDiscount = new Discount() { Id = 1, ProductId = bigMug.Id, RequiredProductCount = 2, TotalPrice = 1.5M };
        var napkinsDiscount = new Discount() { Id = 2, ProductId = napkins.Id, RequiredProductCount = 3, TotalPrice = 0.9M };

        var fixture = new CartTotalPriceProviderFixture();

        var sut = fixture
            .WithCartItem(vase, 1)
            .WithCartItem(bigMug, 5)
            .WithCartItem(napkins, 4)
            .WithDiscount(bigMugDiscount)
            .WithDiscount(napkinsDiscount)
            .CreateSut();

        var total = sut.GetTotalPrice();

        total.Should().Be(6.55M);
    }
}