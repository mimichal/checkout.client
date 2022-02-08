using Checkout.Client;
using Checkout.Client.Cart;
using Checkout.Client.Cart.Models;
using Checkout.Client.Cart.Repositories;
using Microsoft.Extensions.DependencyInjection;

// Register services
var serviceProvider = new ServiceCollection()
    .Register()
    .BuildServiceProvider();


// Use CartService


var vase = new Product() { Id = 1, Name = "Vase", BasePrice = (decimal)1.2 };
var bigMug = new Product() { Id = 2, Name = "Big mug", BasePrice = (decimal)1 };
var napkins = new Product() { Id = 3, Name = "Napkins", BasePrice = (decimal)0.45 };

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
