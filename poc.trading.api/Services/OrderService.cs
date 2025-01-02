using Org.BouncyCastle.Asn1.Ocsp;
using poc.trading.api.Entities.Dto;
using poc.trading.api.Repositpory.Interface;
using poc.trading.api.Services.Interfaces;

namespace poc.trading.api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IStockRepository _stockRepository;

        public OrderService(IOrderRepository orderRepository, IStockRepository stockRepository)
        {
            _orderRepository = orderRepository;
            _stockRepository = stockRepository;
        }

        public async Task<bool> Create(CreateOrderRequest request)
        {
            var stock = await _stockRepository.GetStock(request.StockId);

            if (request.Quantity > stock.AvailableQuantity)
            {
                throw new Exception($"Total Availble quantity of stocks - {stock.AvailableQuantity}. Please select quantity less then available quantity");
            }

            var number = new Random().Next(10000000);
            if (number % 2 == 0)
            {
                throw new Exception($"Your Order has been cancelled. Please try again");
            }

            var response = await _orderRepository.Create(Guid.NewGuid().ToString(), request);

            if (response)
            {
                await _stockRepository.UpdateAvailableQuantity(
                    new Entities.UpdateAvailableQuantityRequest()
                    {
                        StockId = request.StockId,
                        UpdatedQuantity = (stock.AvailableQuantity - request.Quantity)
                    });
            }

            return response;
        }

        public async Task<OrderDetails> GetDetails(string orderId)
        {
            return await _orderRepository.GetDetails(orderId);
        }

        public async Task<List<OrderDetails>> GetOrdersByUser(string userId)
        {
            return await _orderRepository.GetOrdersByUser(userId);
        }
    }
}
