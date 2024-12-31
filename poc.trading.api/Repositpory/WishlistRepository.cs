using poc.trading.api.Entities;
using poc.trading.api.Entities.Dto;
using poc.trading.api.Repositpory.Interface;
using poc.trading.db.Connector;

namespace poc.trading.api.Repositpory
{
    public class WatchlistRepository : IWatchlistRepository
    {
        private readonly ISqlConnector _connector;

        public WatchlistRepository(ISqlConnector connector)
        {
            _connector = connector;
        }

        public async Task<bool> Add(string userId, string stockId)
        {
            return await _connector.Execute(DbConstants.ADD_WATCHLIST, new { userId, stockId }) > 0;
        }

        public async Task<bool> Delete(string userId, string stockId)
        {
            return await _connector.Execute(DbConstants.DELETE_WATCHLIST, new { p_userId = userId, p_stockId  = stockId }) > 0;
        }

        public async Task<List<Stocks>> Get(string userId)
        {
            return (await _connector.GetData<Stocks>(DbConstants.GET_WATCHLIST, new { p_userId = userId })).ToList();
        }
    }
}
