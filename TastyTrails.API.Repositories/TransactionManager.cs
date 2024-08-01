using Microsoft.EntityFrameworkCore.Storage;
using TastyTrails.API.Repositories.Interfaces;

namespace TastyTrails.API.Repositories
{
    public class TransactionManager : ITransactionManager
    {
        private readonly TastyTrailsDbContext _dbContext;

        public TransactionManager(TastyTrailsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return _dbContext.Database.BeginTransactionAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
