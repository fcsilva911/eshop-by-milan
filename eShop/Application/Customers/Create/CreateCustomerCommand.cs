using Application.Abstractions.Messaging;

namespace Application.Customers.Create
{
    public record CreateCustomerCommand(string Email, string Name) : ICommand;

    public record CreateCostumerRequest(string Email, string Name);
}
