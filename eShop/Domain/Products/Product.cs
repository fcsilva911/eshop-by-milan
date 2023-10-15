using Domain.Primitives;

namespace Domain.Products
{
    public class Product : Entity<ProductId>
    {
        public Product(ProductId id, string name, Money money, Sku sku)
            : base(id)
        {

        }

        public string Name { get; private set; } = string.Empty;

        public Money Price { get; private set; }

        public Sku Sku { get; private set; }

        public void Update(string name, Money money, Sku sku)
        {
            // TODO
        }
    }
}
