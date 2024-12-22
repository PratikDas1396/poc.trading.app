using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using poc.trading.api.Entities;
using poc.trading.api.Entities.Dto;
using poc.trading.api.Services.Interfaces;

namespace poc.trading.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StockController : Controller
    {
        private IStockService _service;
        private readonly ILogger<StockController> _logger;

        public StockController(IStockService service, ILogger<StockController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<List<Stocks>> Get()
        {
            return await _service.GetAllStocks();
        }

        [HttpPost("update")]
        public async Task<bool> update(UpdateStockRequest request)
        {
            return await _service.Update(request);
        }
    }
}
