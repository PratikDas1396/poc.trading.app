using Microsoft.AspNetCore.Mvc;
using poc.trading.api.Entities;
using poc.trading.api.Entities.Dto;
using poc.trading.api.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace poc.trading.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private IStockService _service;
        private readonly ILogger<IStockService> _logger;

        public StockController(IStockService service, ILogger<IStockService> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("/GetAll")]
        public async Task<List<Stocks>> Get()
        {
            return await _service.GetAllStocks();
        }

        [HttpPost]
        [Route("/update")]
        public async Task<bool> update(UpdateStockRequest request)
        {
            return await _service.Update(request);
        }
    }
}
