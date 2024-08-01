using Microsoft.Extensions.DependencyInjection;
using TastyTrails.API.Repositories.Interfaces;
using TastyTrails.API.Repositories.Repositories;

namespace TastyTrails.API.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ITransactionManager, TransactionManager>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
