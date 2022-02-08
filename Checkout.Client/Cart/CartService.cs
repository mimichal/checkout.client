﻿using Checkout.Client.Cart.Models;
using Checkout.Client.Cart.Providers;
using Checkout.Client.Cart.Repositories;

namespace Checkout.Client.Cart;

public interface ICartService
{
    void Add(Product product);

    void Remove(Product product);

    decimal GetTotal();

    List<CartItem> GetItems();

}

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly ICartTotalPriceProvider _cartTotalPriceProvider;

    public CartService(ICartRepository cartRepository, ICartTotalPriceProvider cartTotalPriceProvider)
    {
        _cartRepository = cartRepository;
        _cartTotalPriceProvider = cartTotalPriceProvider;
    }

    public void Add(Product product)
    {
        _cartRepository.Add(product);
    }

    public List<CartItem> GetItems()
    {
        return _cartRepository.GetItems();
    }

    public decimal GetTotal()
    {
        return _cartTotalPriceProvider.GetTotalPrice();
    }

    public void Remove(Product product)
    {
        _cartRepository.Remove(product);
    }
}