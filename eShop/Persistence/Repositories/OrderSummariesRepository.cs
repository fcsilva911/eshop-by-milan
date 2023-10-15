using Domain.Orders;

namespace Persistence.Repositories
{
    internal sealed class OrderSummariesRepository : Repository<OrderSummary, int>
    {
        public OrderSummariesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
