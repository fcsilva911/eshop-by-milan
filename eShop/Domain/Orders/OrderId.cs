namespace Domain.Orders
{
    public class OrderId
    {
        public OrderId(Guid id)
        {
            Value = id;
        }

        public Guid Value { get; private set; }
    }
}
