using Application.Abstractions.Messaging;
using Domain.Products;

namespace Application.Products.Update
{
    public record UpdateProductCommand(
        ProductId Id,
        string Name,
        string Sku,
        string Currency,
        string Amount) : ICommand;

    public record UpdateProductRequest(string Name, string Sku, string Currency, string Amount);

}
