namespace Domain.Customers
{
    public class CustomerId
    {
        public CustomerId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; set; }
    }
}
