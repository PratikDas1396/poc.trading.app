using Microsoft.AspNetCore.SignalR;
using poc.trading.api.Entities;
using poc.trading.api.Entities.Dto;
using poc.trading.api.Repositpory.Interface;
using poc.trading.api.Services.Interfaces;
using poc.trading.signalr.Handler;
using poc.trading.signalr.Hubs;

namespace poc.trading.api.Services
{
    public class StockService : IStockService
    {
        private IStockRepository _repository;
        private readonly IHubContext<TradingHub> _hubContext;
        private readonly IClientHandler _clientHandler;

        public StockService(IStockRepository repository, IHubContext<TradingHub> hubContext)
        {
            _repository = repository;
            _hubContext = hubContext;
        }

        public async Task<List<Stocks>> GetAllStocks()
        {
            return await _repository.GetAllStocks();
        }

        public async Task<bool> Update(UpdateStockRequest request)
        {
            var response = await _repository.UpdateStock(request);
            if (response)
                await _hubContext.Clients.All.SendAsync("stock-update", request);
            return response;
        }
    }
}
