﻿using Domain.Primitives;

namespace Domain.Orders
{
    public record LineItemAddedDomainEvent(Guid Id, OrderId OrderId, LineItemId LineItemId) : DomainEvent(Id);
}
