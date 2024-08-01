using TastyTrails.API.Repositories.GenericRepository;
using TastyTrails.API.Repositories.Interfaces;
using TastyTrails.API.Repositories.Models;

namespace TastyTrails.API.Repositories.Repositories
{
    public class OrderRepository : GenericRepository<TastyTrailsDbContext, Order>, IOrderRepository
    {
        public OrderRepository(TastyTrailsDbContext dbContext)
            : base(dbContext)
        {
            
        }

        public async Task AddOrder(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
        }
    }
}
