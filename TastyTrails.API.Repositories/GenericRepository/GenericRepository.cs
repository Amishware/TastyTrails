using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TastyTrails.API.Repositories.GenericRepository
{
    public class GenericRepository<TDbContext, TEntity> : IGenericRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : class, IEntity
    {
        public readonly TDbContext _dbContext;

        public GenericRepository(TDbContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>()
                        .AsNoTracking()
                        .ToListAsync();
        }
    }
}
