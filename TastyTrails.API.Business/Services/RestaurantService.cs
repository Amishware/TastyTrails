using TastyTrails.API.Business.Interfaces;
using TastyTrails.API.Business.Models.Dtos;
using TastyTrails.API.Business.Models.Responses;
using TastyTrails.API.Repositories.Interfaces;
using TastyTrails.API.Repositories.Models;

namespace TastyTrails.API.Business.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<GetAllRestaurantsResponse> GetAllWithOffer()
        {
            var restaurants = await _restaurantRepository.GetAllWithSupplyAndOffer();

            return new GetAllRestaurantsResponse
            {
                Restaurants = restaurants.Select(m => new RestaurantDto
                {
                    Id = m.Id,
                    Menu = new MenuDto
                    {
                        MenuItems = CalculateMenuQuantity(m.Supply, m.Menu)
                    },
                    PaymentDetailsId = m.PaymentDetailsId,
                    Name = m.Name,
                    Address = m.Address,
                    Location = m.Location,
                    Email = m.Email,
                    Phone = m.Phone
                })
            };
        }

        private static IEnumerable<MenuItemDto> CalculateMenuQuantity(Supply supply, Menu menu)
        {
            var supplyItemsDict = supply.SupplyItems.ToDictionary(k => k.IngredientId, v => v.Quantity);

            return menu.MenuItems.Select(m => new MenuItemDto
            {
                Name = m.Name,
                Price = m.Price,
                ImageUrl = m.ImageUrl,
                AvailableQuantity = CalculateItemQuantity(supplyItemsDict, m),
            });
        }

        private static int CalculateItemQuantity(Dictionary<int, double> supplyItemsDict, MenuItem menuItem)
        {
            var finalQuantity = int.MaxValue;

            foreach (var ingredientQuantity in menuItem.IngredientQuantities)
            {
                if (ingredientQuantity.Quantity <= 0)
                    continue;
                if (supplyItemsDict.TryGetValue(ingredientQuantity.IngredientId, out var supplyQuantity))
                {
                    var itemCount = (int)(supplyQuantity / ingredientQuantity.Quantity);
                    if (itemCount < finalQuantity)
                        finalQuantity = itemCount;
                }
                else
                {
                    return 0;
                }
            }

            return finalQuantity;
        }
    }
}
