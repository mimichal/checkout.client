using Checkout.Application.Cart.Models;

namespace Checkout.Application.Cart.Repositories;

public interface ICartRepository
{
    void Add(Product product);

    void Remove(Product product);

    List<CartItem> GetItems();
}

public class CartRepository : ICartRepository
{
    private Dictionary<int, CartItem> _products = new Dictionary<int, CartItem>();


    public void Add(Product product)
    {
        if(!_products.ContainsKey(product.Id))
        {
            _products.Add(product.Id, new CartItem() { Product = product, Count = 1});
        }
        else
        {
            _products[product.Id].Count++;
        }        
    }

    public void Remove(Product product)
    {
        if (_products.ContainsKey(product.Id))
        {
            _products[product.Id].Count--;

            if (_products[product.Id].Count <= 0)
            {
                _products.Remove(product.Id);                
            }
        }        
    }

    public List<CartItem> GetItems()
    {
        return _products.Values.ToList();
    }
}