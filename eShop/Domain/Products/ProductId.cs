﻿namespace Domain.Products
{
    public class ProductId
    {
        public ProductId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
