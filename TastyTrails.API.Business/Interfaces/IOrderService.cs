using TastyTrails.API.Business.Models.Requests;
using TastyTrails.API.Business.Models.Responses;

namespace TastyTrails.API.Business.Interfaces
{
    public interface IOrderService
    {
        public Task<CreateOrderResponse> CreateOrder(CreateChannelOrderRequest request);
    }
}
