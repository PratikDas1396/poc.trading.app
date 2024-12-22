using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using poc.trading.api.Entities.Dto;
using poc.trading.api.Services.Interfaces;

namespace poc.trading.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController
    {
        private IOrderService _service;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService service, ILogger<OrderController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<bool> Create([FromBody] CreateOrderRequest request)
        {
            return await _service.Create(request);
        }

        [HttpGet("{orderId}")]
        public async Task<OrderDetails> GetOrderDetails(string orderId)
        {
            return await _service.GetDetails(orderId);
        }

        [HttpGet("{userId}/orders")]
        public async Task<List<OrderDetails>> GetUserOrderDetails(string userId)
        {
            return await _service.GetOrdersByUser(userId);
        }
    }
}
