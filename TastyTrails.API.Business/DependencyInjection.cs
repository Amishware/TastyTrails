using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TastyTrails.API.Business.Interfaces;
using TastyTrails.API.Business.Models.Dtos;
using TastyTrails.API.Business.Models.Requests;
using TastyTrails.API.Business.Services;

namespace TastyTrails.API.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<OrderItemDto>, OrderItemDtoValidator>();
            services.AddTransient<IValidator<CreateOrderRequest>, CreateOrderRequestValidator<CreateOrderRequest>>();
            services.AddTransient<CreateOrderRequestValidator<CreateChannelOrderRequest>, CreateChannelOrderRequestValidator>();

            return services;
        }
    }
}