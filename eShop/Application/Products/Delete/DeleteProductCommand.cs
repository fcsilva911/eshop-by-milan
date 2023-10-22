using Application.Abstractions.Messaging;
using Domain.Products;

namespace Application.Products.Delete
{
    public record DeleteProductCommand(ProductId Id) : ICommand;
}
