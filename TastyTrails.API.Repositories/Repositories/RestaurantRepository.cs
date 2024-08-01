using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TastyTrails.API.Repositories.GenericRepository;
using TastyTrails.API.Repositories.Interfaces;
using TastyTrails.API.Repositories.Models;

namespace TastyTrails.API.Repositories.Repositories
{
    public class RestaurantRepository : GenericRepository<TastyTrailsDbContext, Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(TastyTrailsDbContext dbContext)
            : base(dbContext)
        { }

        public async Task<IEnumerable<Restaurant>> GetAllWithSupplyAndOffer()
        {
            return await _dbContext.Restaurants
                        .AsNoTracking()
                        .Include(p => p.Supply)
                        .ThenInclude(p => p.SupplyItems)
                        .Include(p => p.Menu)
                        .ThenInclude(p => p.MenuItems)
                        .ThenInclude(p => p.IngredientQuantities)
                        .ToListAsync();
        }

        public async Task<Restaurant> GetById(int id)
        {
            return await _dbContext.Restaurants
                        .Include(p => p.Supply)
                        .ThenInclude(p => p.SupplyItems)
                        .Include(p => p.Menu)
                        .ThenInclude(p => p.MenuItems)
                        .ThenInclude(p => p.IngredientQuantities)
                        .Where(p => p.Id == id)
                        .FirstAsync();
        }
    }
}
