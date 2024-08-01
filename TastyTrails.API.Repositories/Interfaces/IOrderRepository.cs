using TastyTrails.API.Repositories.Models;

namespace TastyTrails.API.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order);
    }
}
