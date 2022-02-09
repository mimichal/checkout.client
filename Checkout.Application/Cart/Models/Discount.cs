namespace Checkout.Application.Cart.Models;

public class Discount
{
    public int Id { get; set; }

    public int ProductId { get; set; }    

    public int RequiredProductCount { get; set; }

    public decimal TotalPrice { get; set; }
}
