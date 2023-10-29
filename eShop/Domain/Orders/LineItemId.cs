namespace Domain.Orders
{
    public class LineItemId
    {
        public LineItemId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
