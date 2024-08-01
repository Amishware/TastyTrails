using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TastyTrails.API.Business.Interfaces;
using TastyTrails.API.Business.Services;
using TastyTrails.API.Repositories.Interfaces;
using TastyTrails.API.Repositories.Models;

namespace TastyTrails.API.UnitTests
{
    [TestFixture]
    public class RestaurantServiceTests
    {
        private Mock<IRestaurantRepository> _restaurantRepositoryMock;
        private IRestaurantService _restaurantService;

        [SetUp]
        public void Setup()
        {
            var restaurant = Helper.CreateRestaurantAndOffer();

            _restaurantRepositoryMock = new Mock<IRestaurantRepository>();
            _restaurantRepositoryMock.Setup(a => a.GetAllWithSupplyAndOffer()).ReturnsAsync(new List<Restaurant>() { restaurant });

            _restaurantService = new RestaurantService(_restaurantRepositoryMock.Object);
        }

        [Test]
        public async Task AvailableManuItemQuantitiesTest()
        {
            var result = await _restaurantService.GetAllWithOffer();

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Restaurants);
            Assert.AreEqual(1, result.Restaurants.Count());
            var restaurant = result.Restaurants.FirstOrDefault();
            Assert.IsNotNull(restaurant);
            Assert.IsNotNull(restaurant.Menu);
            Assert.IsNotEmpty(restaurant.Menu.MenuItems);
            Assert.AreEqual(2, restaurant.Menu.MenuItems.Count());
            var item1 = restaurant.Menu.MenuItems.FirstOrDefault();
            var item2 = restaurant.Menu.MenuItems.LastOrDefault();
            Assert.IsNotNull(item1);
            Assert.IsNotNull(item2);
            Assert.AreEqual("Salad", item1.Name);
            Assert.AreEqual("Salad 2", item2.Name);
            Assert.AreEqual(10, item1.AvailableQuantity);
            Assert.AreEqual(5, item2.AvailableQuantity);

            Assert.Pass();
        }
    }
}