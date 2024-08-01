using TastyTrails.API.Business.Interfaces;
using TastyTrails.API.Business.Models.Requests;
using TastyTrails.API.Business.Models.Responses;
using TastyTrails.API.Repositories;
using TastyTrails.API.Repositories.Interfaces;
using TastyTrails.API.Repositories.Models;

namespace TastyTrails.API.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly ITransactionManager _transactionManager;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(
            ITransactionManager transactionManager,
            IRestaurantRepository restaurantRepository,
            IOrderRepository orderRepository)
        {
            _transactionManager = transactionManager;
            _restaurantRepository = restaurantRepository;
            _orderRepository = orderRepository;
        }

        public async Task<CreateOrderResponse> CreateOrder(CreateChannelOrderRequest request)
        {
            var order = new Order
            {
                RestaurantId = request.RestaurantId,
                CustomerId = request.CustomerId,
                PartnerId = request.PartnerId,
                OrderItems = request.OrderItems.Select(i => new OrderItem
                {
                    MenuItemId = i.MenuItemId,
                    Quantity = i.Quantity,
                }).ToList(),
            };

            using (var t = await _transactionManager.BeginTransactionAsync())
            {
                try
                {
                    var restaurant = await _restaurantRepository.GetById(order.RestaurantId);

                    UpdateSuppliesAndPrices(order, restaurant);

                    order.Price = CalculateTotalPrice(order.OrderItems);
                    order.Status = "Ordered";

                    await _orderRepository.AddOrder(order);
                    await _transactionManager.SaveChangesAsync();
                    await t.CommitAsync();
                }
                catch
                {
                    await t.RollbackAsync();
                    throw;
                }
            }

            return new CreateOrderResponse
            {
                Price = order.Price,
                Status = order.Status,
                CreatedOn = order.CreatedOn,
            };
        }

        private static void UpdateSuppliesAndPrices(Order order, Restaurant restaurant)
        {
            var supplyItemQuantities = restaurant.Supply.SupplyItems.ToDictionary(s => s.IngredientId);
            var menuItems = restaurant.Menu.MenuItems;
            foreach (var orderItem in order.OrderItems)
            {
                var menuItem = menuItems.FirstOrDefault(m => m.Id == orderItem.MenuItemId);
                if (menuItem == null)
                {
                    throw new ArgumentException(string.Format("Menu item with id = {0} does not exist in this restaurant", orderItem.MenuItemId), nameof(orderItem.MenuItemId));
                }

                UpdateSupplies(supplyItemQuantities, orderItem, menuItem);
                orderItem.Price = menuItem.Price;
            }
        }

        private static void UpdateSupplies(Dictionary<int, SupplyItem> supplyItemQuantities, OrderItem orderItem, MenuItem menuItem)
        {
            foreach (var ingredientQuantity in menuItem.IngredientQuantities)
            {
                if (ingredientQuantity.Quantity <= 0)
                {
                    continue;
                }
                if (supplyItemQuantities.TryGetValue(ingredientQuantity.IngredientId, out var supplyQuantity))
                {
                    if (ingredientQuantity.Quantity * orderItem.Quantity < supplyQuantity.Quantity)
                    {
                        supplyQuantity.Quantity -= ingredientQuantity.Quantity * orderItem.Quantity;
                    }
                    else
                    {
                        throw new KeyNotFoundException(string.Format("Order can not be delivered because ingredient with id = {0} is not in sufficient quantity in this restaurant", ingredientQuantity.IngredientId));
                    }
                }
                else
                {
                    throw new KeyNotFoundException(string.Format("Order can not be delivered because ingredient with id = {0} is missing in this restaurant", ingredientQuantity.IngredientId));
                }
            }
        }

        private static double CalculateTotalPrice(IEnumerable<OrderItem> orderItems)
        {
            return orderItems.Sum(o => o.Price * o.Quantity);
        }
    }
}
