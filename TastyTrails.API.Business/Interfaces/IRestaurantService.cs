using TastyTrails.API.Business.Models.Responses;

namespace TastyTrails.API.Business.Interfaces
{
    public interface IRestaurantService
    {
        public Task<GetAllRestaurantsResponse> GetAllWithOffer();
    }
}
