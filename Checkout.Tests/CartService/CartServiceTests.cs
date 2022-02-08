using Checkout.Client.Cart.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Checkout.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void Should_Add_Products_To_Cart()
        {
            var vase = new Product() { Id = 1, Name = "Vase", BasePrice = 1.2M };
            var bigMug = new Product() { Id = 2, Name = "Big mug", BasePrice = 1M };
            var napkins = new Product() { Id = 3, Name = "Napkins", BasePrice = 0.45M };

            var fixture = new CartServiceFixture();

            var sut = fixture.CreateSut();

            sut.Add(vase);
            sut.Add(bigMug);
            sut.Add(napkins);

            var cartItems = sut.GetItems();

            cartItems.Should().HaveCount(3);
        }

        [Test]
        public void Should_Remove_Products_From_Full_Cart()
        {
            var vase = new Product() { Id = 1, Name = "Vase", BasePrice = 1.2M };
            var bigMug = new Product() { Id = 2, Name = "Big mug", BasePrice = 1M };
            var napkins = new Product() { Id = 3, Name = "Napkins", BasePrice = 0.45M };

            var fixture = new CartServiceFixture();

            var sut = fixture.CreateSut();

            sut.Add(vase);
            sut.Add(bigMug);
            sut.Add(napkins);
            sut.Remove(bigMug);

            var cartItems = sut.GetItems();

            cartItems.Should().HaveCount(2);
            cartItems.Should().NotContain(x => x.Product.Id.Equals(bigMug.Id));
        }

        [Test]
        public void Should_Remove_Products_From_Empty_Cart()
        {
            var bigMug = new Product() { Id = 2, Name = "Big mug", BasePrice = 1M };

            var fixture = new CartServiceFixture();

            var sut = fixture.CreateSut();
          
            sut.Remove(bigMug);

            var cartItems = sut.GetItems();

            cartItems.Should().BeEmpty();            
        }
        
        [Test]
        public void Should_Calculate_Total_Price_Without_Discounts()
        {
            var vase = new Product() { Id = 1, Name = "Vase", BasePrice = 1.2M };
            var bigMug = new Product() { Id = 2, Name = "Big mug", BasePrice = 1M };
            var napkins = new Product() { Id = 3, Name = "Napkins", BasePrice = 0.45M };

            var fixture = new CartServiceFixture();

            var sut = fixture.CreateSut();

            sut.Add(vase);
            sut.Add(bigMug);
            sut.Add(napkins);

            var totalPrice = sut.GetTotal();

            totalPrice.Should().Be(2.65M);
        }

        [Test]
        public void Should_Calculate_Total_Price_With_Discounts()
        {
            var vase = new Product() { Id = 1, Name = "Vase", BasePrice = 1.2M };
            var bigMug = new Product() { Id = 2, Name = "Big mug", BasePrice = 1M };
            var napkins = new Product() { Id = 3, Name = "Napkins", BasePrice = 0.45M };

            var bigMugDiscount = new Discount() { Id = 1, ProductId = bigMug.Id, RequiredProductCount = 2, TotalPrice = 1.5M};
            var napkinsDiscount = new Discount() { Id = 2, ProductId = napkins.Id, RequiredProductCount = 3, TotalPrice = 0.9M };

            var fixture = new CartServiceFixture();

            var sut = fixture
                .WithDiscount(bigMugDiscount)
                .WithDiscount(napkinsDiscount)
                .CreateSut();

            sut.Add(vase);
            sut.Add(bigMug);
            sut.Add(bigMug);
            sut.Add(bigMug);
            sut.Add(bigMug);
            sut.Add(bigMug);
            sut.Add(napkins);
            sut.Add(napkins);
            sut.Add(napkins);
            sut.Add(napkins);

            var totalPrice = sut.GetTotal();

            totalPrice.Should().Be(6.55M);
        }
    }
}