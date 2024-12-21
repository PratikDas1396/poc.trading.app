using poc.trading.api.Entities.Dto;

namespace poc.trading.api.Services.Interfaces
{
    public interface IWatchlistService
    {
        public Task<bool> Add(string userId, string stockId);
        public Task<bool> Delete(string userId, string stockId);
        public Task<List<Stocks>> Get(string userId);

    }
}
