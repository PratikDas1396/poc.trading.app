using poc.trading.api.Entities;
using poc.trading.api.Entities.Dto;

namespace poc.trading.api.Services.Interfaces
{
    public interface IStockService
    {
        public Task<List<Stocks>> GetAllStocks();
        public Task<bool> Update(UpdateStockRequest request);
    }
}
