using Checkout.Application.Cart.Repositories;

namespace Checkout.Application.Cart.Providers;

public interface ICartTotalPriceProvider
{
    decimal GetTotalPrice();
}

public class CartTotalPriceProvider : ICartTotalPriceProvider
{
    public ICartRepository _cartRepository;
    public IDiscountRepository _discountRepository;

    public CartTotalPriceProvider(ICartRepository cartRepository, IDiscountRepository discountRepository)
    {
        _cartRepository = cartRepository;
        _discountRepository = discountRepository;
    }

    public decimal GetTotalPrice()
    {
        decimal total = 0;
        
        var discounts = _discountRepository.GetAll().ToDictionary(x => x.ProductId, x => x);

        foreach (var item in _cartRepository.GetItems())
        {            
            if (discounts.ContainsKey(item.Product.Id))
            {
                var discount = discounts[item.Product.Id];
                var discountPrice = (item.Count / discount.RequiredProductCount) * discount.TotalPrice;
                var rest = (item.Count % discount.RequiredProductCount) * item.Product.BasePrice;
                
                total += discountPrice + rest;
            }
            else
            {
                total += item.Product.BasePrice * item.Count;
            }            
        }

        return total;
    }
}