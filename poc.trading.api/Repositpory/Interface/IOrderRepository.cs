using poc.trading.api.Entities.Dto;

namespace poc.trading.api.Repositpory.Interface
{
    public interface IOrderRepository
    {
        public Task<bool> Create(string orderId, CreateOrderRequest request);
        public Task<List<OrderDetails>> GetOrdersByUser(string userId);
        public Task<OrderDetails> GetDetails(string orderId);
    }
}
