using Checkout.Application;
using Checkout.Application.Cart;
using Checkout.Application.Cart.Models;
using Checkout.Application.Cart.Repositories;
using Microsoft.Extensions.DependencyInjection;

// Register services
var serviceProvider = new ServiceCollection()
    .Register()
    .BuildServiceProvider();


// Prepare products
var vase = new Product() { Id = 1, Name = "Vase", BasePrice = 1.2M };
var bigMug = new Product() { Id = 2, Name = "Big mug", BasePrice = 1M };
var napkins = new Product() { Id = 3, Name = "Napkins", BasePrice = 0.45M };

// and discounts
var discountRepository = serviceProvider.GetService<IDiscountRepository>();

var bigMugDiscount = new Discount() { Id = 1, ProductId = bigMug.Id, RequiredProductCount = 2, TotalPrice = 1.5M };
var napkinsDiscount = new Discount() { Id = 2, ProductId = napkins.Id, RequiredProductCount = 3, TotalPrice = 0.9M };

discountRepository.Add(bigMugDiscount);
discountRepository.Add(napkinsDiscount);

var cartService = serviceProvider.GetService<ICartService>();

cartService.Add(vase);
cartService.Add(vase);
cartService.Add(bigMug);
cartService.Add(bigMug);
cartService.Add(bigMug);
cartService.Add(napkins);
cartService.Add(napkins);
cartService.Add(napkins);
cartService.Add(napkins);

Console.WriteLine("Name\tPrice\tCount");
Console.WriteLine("------------------------");
cartService.GetItems().ForEach(x => Console.WriteLine($"{x.Product.Name}\t{x.Product.BasePrice}\t{x.Count}"));


Console.WriteLine($"Total price: {cartService.GetTotal()}");

Console.ReadKey();
