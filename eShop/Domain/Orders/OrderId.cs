namespace Domain.Orders
{
    public class OrderId
    {
        public OrderId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
