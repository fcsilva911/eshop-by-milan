using Domain.Products;

namespace Domain.Orders
{
    public record LineItem(LineItemId Id, OrderId OrderId, ProductId ProductId, Money Price);
}
