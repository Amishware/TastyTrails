using Microsoft.AspNetCore.Mvc;
using TastyTrails.API.Business.Interfaces;
using TastyTrails.API.Business.Models.Requests;
using TastyTrails.API.Business.Models.Responses;
using TastyTrails.Common.API;
using TastyTrails.Common.Authorization;
using TastyTrails.Common.Interfaces;

namespace TastyTrails.API.SelfServingKiosk.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;
        //private readonly IUserMetaReader _userMetaReader;

        public OrderController(
            ILoggerFactory loggerFactory,
            IOrderService orderService)
            : base(loggerFactory)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        //[Permission(
        //    SystemPermissions.RestaurantRead, 
        //    SystemPermissions.SupplyWrite, 
        //    SystemPermissions.MenuRead,
        //    SystemPermissions.OrderRead,
        //    SystemPermissions.OrderWrite)]
        public async Task<CreateOrderResponse> GetAll(CreateChannelOrderRequest request)
        {
            return await _orderService.CreateOrder(request);
        }
    }
}
