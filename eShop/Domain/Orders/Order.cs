﻿using Domain.Customers;
using Domain.Primitives;
using Domain.Products;

namespace Domain.Orders
{
    public class Order : Entity<OrderId>
    {
        private readonly List<LineItem> _lineItems = new();

        private Order()
        {
        }

        public CustomerId CustomerId { get; private set; }

        public IReadOnlyList<LineItem> LineItems => _lineItems.ToList();

        public static Order Create(CustomerId customerId)
        {
            var order = new Order()
            {
                Id = new OrderId(Guid.NewGuid()),
                CustomerId = customerId
            };

            order.Raise(new OrderCreatedDomainEvent(Guid.NewGuid(), order.Id));

            return order;
        }

        public void AllLineItem(ProductId productId, Money price)
        {
            var lineItem = new LineItem(
                new LineItemId(Guid.NewGuid()),
                Id,
                productId,
                price);

            _lineItems.Add(lineItem);

            Raise(new LineItemAddedDomainEvent(Guid.NewGuid(), Id, lineItem.Id));
        }

        public void RemoveLineItem(LineItemId lineItemId)
        {
            if (HasOneLineItem())
            {
                return;
            }

            var lineItem = _lineItems.FirstOrDefault(li => li.Id == lineItemId);

            if (lineItem is null)
            {
                return;
            }
            _lineItems.Remove(lineItem);
        }

        // TODO
    }
}
