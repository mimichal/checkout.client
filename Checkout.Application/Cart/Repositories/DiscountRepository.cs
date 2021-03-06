using Checkout.Application.Cart.Models;

namespace Checkout.Application.Cart.Repositories;

public interface IDiscountRepository
{
    void Add(Discount discount);

    List<Discount> GetAll();
}

public class DiscountRepository : IDiscountRepository
{
    private List<Discount> _discounts = new List<Discount>();

    public void Add(Discount discount)
    {
        _discounts.Add(discount);
    }

    public List<Discount> GetAll()
    {
        return _discounts;
    }
}