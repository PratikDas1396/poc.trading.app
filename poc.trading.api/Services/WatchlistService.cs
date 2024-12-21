using poc.trading.api.Entities.Dto;
using poc.trading.api.Repositpory.Interface;
using poc.trading.api.Services.Interfaces;

namespace poc.trading.api.Services
{
    public class WatchlistService : IWatchlistService
    {
        private readonly IWatchlistRepository _watchlistRepository;

        public WatchlistService(IWatchlistRepository watchlistRepository)
        {
            _watchlistRepository = watchlistRepository;
        }

        public async Task<bool> Add(string userId, string stockId)
        {
            return await _watchlistRepository.Add(userId, stockId);
        }

        public async Task<bool> Delete(string userId, string stockId)
        {
            return await _watchlistRepository.Delete(userId, stockId);
        }

        public async Task<List<Stocks>> Get(string userId)
        {
            return await _watchlistRepository.Get(userId);
        }
    }
}
