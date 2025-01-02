using poc.trading.api.Entities;
using poc.trading.api.Entities.Dto;
using poc.trading.api.Repositpory.Interface;
using poc.trading.db.Connector;

namespace poc.trading.api.Repositpory
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ISqlConnector _connector;
        private readonly IStockRepository _stock;

        public OrderRepository(ISqlConnector connector, IStockRepository stock)
        {
            _connector = connector;
            _stock = stock;
        }

        public async Task<bool> Create(string orderId, CreateOrderRequest request)
        {
            request.Id = orderId;
            return await _connector.Execute(DbConstants.CREATE_ORDER, request) > 0;
        }

        public async Task<OrderDetails> GetDetails(string orderId)
        {
            return await _connector.GetSingleData<OrderDetails>(DbConstants.GET_ORDER_DETAILS, new { orderId });
        }

        public async Task<List<OrderDetails>> GetOrdersByUser(string userId)
        {
            return (await _connector.GetData<OrderDetails>(DbConstants.GET_ORDER_BY_USER, new { userId })).ToList();
        }
    }
}
