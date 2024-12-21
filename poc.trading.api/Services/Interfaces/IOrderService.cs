using poc.trading.api.Entities.Dto;

namespace poc.trading.api.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> Create(CreateOrderRequest request);
        public Task<List<OrderDetails>> GetOrdersByUser(string userId);
        public Task<OrderDetails> GetDetails(string orderId);
    }
}
