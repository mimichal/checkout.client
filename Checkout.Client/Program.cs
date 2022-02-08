using Checkout.Client;
using Checkout.Client.Cart;
using Checkout.Client.Cart.Models;
using Microsoft.Extensions.DependencyInjection;

// Register services
var serviceProvider = new ServiceCollection()
    .Register()
    .BuildServiceProvider();


// Use CartService
var cartService = serviceProvider.GetService<ICartService>();

var vase = new Product() { Id = 1, Name = "Vase", BasePrice = (decimal) 1.2 };
var bigMug = new Product() { Id = 2, Name = "Big mug", BasePrice = (decimal) 1 };
var napkins = new Product() { Id = 3, Name = "Napkins", BasePrice = (decimal) 0.45 };

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

Console.ReadKey();
