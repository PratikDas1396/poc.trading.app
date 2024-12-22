using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using poc.trading.api.Entities.Dto;
using poc.trading.api.Services.Interfaces;

namespace poc.trading.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WatchlistController
    {
        private IWatchlistService _service;
        private readonly ILogger<WatchlistController> _logger;

        public WatchlistController(IWatchlistService service, ILogger<WatchlistController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{userId}")]
        public async Task<List<Stocks>> get(string userId)
        {
            return await _service.Get(userId);
        }

        [HttpPost("add")]
        public async Task<bool> Add([FromBody] WatchlistRequest request)
        {
            return await _service.Add(request.UserId, request.StockId);
        }

        [HttpPost("delete")]
        public async Task<bool> Delete([FromBody] WatchlistRequest request)
        {
            return await _service.Delete(request.UserId, request.StockId);
        }
    }
}
