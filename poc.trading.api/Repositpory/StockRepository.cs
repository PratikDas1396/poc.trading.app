using poc.trading.api.Entities;
using poc.trading.api.Entities.Dto;
using poc.trading.api.Repositpory.Interface;
using poc.trading.db.Connector;

namespace poc.trading.api.Repositpory
{
    public class StockRepository : IStockRepository
    {
        private readonly ISqlConnector _connector;

        public StockRepository(ISqlConnector connector)
        {
            _connector = connector;
        }

        public async Task<List<Stocks>> GetAllStocks()
        {
            return (await _connector.GetData<Stocks>(AppConstants.GET_ALL_STOCKS)).ToList();
        }

        public async Task<bool> UpdateStock(UpdateStockRequest request)
        {
            return await _connector.Execute(AppConstants.UPDATE_STOCK, request) > 0;
        }
    }
}
