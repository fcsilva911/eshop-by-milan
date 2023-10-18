using MediatR;

namespace Application.Products.Create
{
    internal record CreateProductCommand(
        string Name,
        string Currency,
        string Amount,
        string Sku) : IRequest<Guid>;
}
