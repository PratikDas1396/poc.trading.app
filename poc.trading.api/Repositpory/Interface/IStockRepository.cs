using poc.trading.api.Entities;
using poc.trading.api.Entities.Dto;

namespace poc.trading.api.Repositpory.Interface
{
    public interface IStockRepository
    {
        public Task<List<Stocks>> GetAllStocks();
        public Task<bool> UpdateStock(UpdateStockRequest request);
        Task<Stocks> GetStock(string Id);
    }
}
