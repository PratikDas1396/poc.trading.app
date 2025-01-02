using poc.trading.api.Entities;
using poc.trading.api.Entities.Dto;

namespace poc.trading.api.Repositpory.Interface
{
    public interface IStockRepository
    {
        public Task<List<Stocks>> GetAllStocks(string userId);
        public Task<bool> UpdateStock(UpdateStockRequest request);
        public Task<bool> UpdateAvailableQuantity(UpdateAvailableQuantityRequest request);
        Task<Stocks> GetStock(string Id);
    }
}