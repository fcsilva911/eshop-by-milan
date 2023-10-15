using Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    internal sealed class CostumerRepository : Repository<Customer, CustomerId>, ICustomerRepository
    {
        public CostumerRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !await DbContext.Customers.AnyAsync(c => c.Email == email);
        }
    }
}
