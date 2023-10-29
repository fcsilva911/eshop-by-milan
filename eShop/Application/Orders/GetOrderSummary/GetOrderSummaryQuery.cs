using Application.Abstractions.Messaging;
using Domain.Orders;

namespace Application.Orders.GetOrderSummary
{
    public record GetOrderSummaryQuery(Guid Id) : ICommand<OrderSummary?>;
}
