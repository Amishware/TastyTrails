using Microsoft.AspNetCore.Mvc;
using TastyTrails.API.Business.Interfaces;
using TastyTrails.API.Business.Models.Responses;
using TastyTrails.Common.API;
using TastyTrails.Common.Authorization;
using TastyTrails.Common.Interfaces;

namespace TastyTrails.API.SelfServingKiosk.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly IRestaurantService _restaurantService;
        //private readonly IUserMetaReader _userMetaReader;

        public RestaurantController(
            ILoggerFactory loggerFactory,
            IRestaurantService restaurantService
            //IUserMetaReader userMetaReader
            )
            : base(loggerFactory)
        {
            _restaurantService = restaurantService;
            //_userMetaReader = userMetaReader;
        }

        [HttpGet("all")]
        //[Permission(SystemPermissions.RestaurantRead, SystemPermissions.SupplyRead, SystemPermissions.MenuRead)]
        public async Task<GetAllRestaurantsResponse> GetAll()
        {
            return await _restaurantService.GetAllWithOffer();
        }
    }
}
