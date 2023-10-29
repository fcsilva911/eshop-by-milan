using Application.Abstractions.Messaging;

namespace Application.Orders.Create
{
    public record CreateOrderCommand(Guid CustomerId) : ICommand;
}