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
            return (await _connector.GetData<Stocks>(DbConstants.GET_ALL_STOCKS)).ToList();
        }

        public async Task<Stocks> GetStock(string Id)
        {
            return (await _connector.GetSingleData<Stocks>(DbConstants.GET_STOCKS, new { stockId = Id }));
        }

        public async Task<bool> UpdateStock(UpdateStockRequest request)
        {
            return await _connector.Execute(DbConstants.UPDATE_STOCK, request) > 0;
        }
    }
}
