using TastyTrails.API.Repositories.Models;

namespace TastyTrails.API.Repositories.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetAllWithSupplyAndOffer();
        Task<Restaurant> GetById(int id);
    }
}
