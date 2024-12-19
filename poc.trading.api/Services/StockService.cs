using poc.trading.api.Entities;
using poc.trading.api.Entities.Dto;
using poc.trading.api.Repositpory.Interface;
using poc.trading.api.Services.Interfaces;

namespace poc.trading.api.Services
{
    public class StockService : IStockService
    {
        private IStockRepository _repository;

        public StockService(IStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Stocks>> GetAllStocks()
        {
            return await _repository.GetAllStocks();
        }

        public async Task<bool> Update(UpdateStockRequest request)
        {
            return await _repository.UpdateStock(request);
        }
    }
}
