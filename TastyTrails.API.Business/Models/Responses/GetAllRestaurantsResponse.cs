using TastyTrails.API.Business.Models.Dtos;

namespace TastyTrails.API.Business.Models.Responses
{
    public class GetAllRestaurantsResponse
    {
        public IEnumerable<RestaurantDto> Restaurants { get; set; }
    }
}
